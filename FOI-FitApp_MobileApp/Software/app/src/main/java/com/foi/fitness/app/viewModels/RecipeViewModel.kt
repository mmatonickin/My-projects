package com.foi.fitness.app.viewModels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.foi.fitness.app.database.DAO.RecipeDAO
import com.foi.fitness.app.entities.Recipe
import com.foi.fitness.app.repositories.RecipeRepository
import com.foi.fitness.app.utils.RecipeInputValidators
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class RecipeViewModel(private val recipeDao: RecipeDAO) : ViewModel() {
    private val repository = RecipeRepository(recipeDao)

    private val _allRecipes = MutableLiveData<List<Recipe>>()
    private val _recipes = MutableLiveData<List<Recipe>>()
    val recipes: LiveData<List<Recipe>> get() = _recipes

    private val _isLoading = MutableLiveData<Boolean>()
    val isLoading: LiveData<Boolean> get() = _isLoading

    private val _addSuccess = MutableLiveData<Boolean>()
    val addSuccess: LiveData<Boolean> get() = _addSuccess

    private val _message = MutableLiveData<String?>()
    val message: LiveData<String?> get() = _message

    private var currentIngredient: String? = null
    private var currentCaloriesRange: Pair<Int, Int>? = null

    fun loadRecipes() {
        viewModelScope.launch {
            _isLoading.value = true

            try {
                val recipes = withContext(Dispatchers.IO) {
                    repository.getRecipes()
                }

                _allRecipes.value = recipes
                _recipes.value = recipes
            } catch (e: Exception) {
                throw e
            } finally {
                _isLoading.value = false
            }
        }
    }

    fun addRecipe (recipe: Recipe) {
        val requiredFieldsMessage = RecipeInputValidators.validateRequiredFields(
            recipe.recipeName,
            recipe.ingredients,
            recipe.procedure,
            recipe.calories.toString(),
        )

        if(requiredFieldsMessage != null){
            _message.value=requiredFieldsMessage
            return
        }

        val caloriesUnsufficient = RecipeInputValidators.validateCalories(recipe.calories.toString())
        if(caloriesUnsufficient != null){
            _message.value=caloriesUnsufficient
            return
        }
        viewModelScope.launch {
            val result = repository.insertRecipes(recipe)
            if(result.isSuccess){
                _message.value="Recipe added!"
                _addSuccess.value=true
                loadRecipes()
            } else {
                _message.value="Failed to add recipe"
                _addSuccess.value=false
            }
        }
    }

    fun setIngredientFilter(ingredient: String?) {
        currentIngredient = ingredient?.takeIf { it.isNotBlank() }
        updateRecipeList()
    }

    fun setCaloriesRange(min: Int?, max: Int?) {
        currentCaloriesRange = if (min != null && max != null) min to max else null
        updateRecipeList()
    }

    private fun updateRecipeList() {
        var filtered = _allRecipes.value ?: return

        currentIngredient?.let { ingredient ->
            filtered = filtered.filter {
                it.ingredients.contains(ingredient, ignoreCase = true)
            }
        }

        currentCaloriesRange?.let { (min, max) ->
            filtered = filtered.filter {
                it.calories in min..max
            }
        }

        _recipes.value = filtered
    }

    fun resetFilters() {
        currentIngredient = null
        currentCaloriesRange = null
        _recipes.value = _allRecipes.value
    }
}
