package com.foi.fitness.app.viewModels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.foi.fitness.app.database.DAO.RecipeDAO
import com.foi.fitness.app.entities.FavoriteRecipe
import com.foi.fitness.app.entities.Recipe
import com.foi.fitness.app.repositories.RecipeRepository
import kotlinx.coroutines.launch

class RecipeDetailViewModel(private val recipeDAO: RecipeDAO, private val repository: RecipeRepository): ViewModel() {

    private val _isFavorite = MutableLiveData<Boolean>()
    val isFavorite: LiveData<Boolean> get() = _isFavorite

    private val _recipe = MutableLiveData<Recipe>()
    val recipe: LiveData<Recipe> get() = _recipe

    fun loadFavoriteStatus(userId: Int, recipeId: String) {
        viewModelScope.launch {
            val favorite = recipeDAO.isFavorite(userId, recipeId)
            _isFavorite.value = favorite
        }
    }

    fun toggleFavorite(userId: Int, recipeId: String) {

        viewModelScope.launch {
            val isFavoriteRecipe = recipeDAO.isFavorite(userId, recipeId)

            if(isFavoriteRecipe) {
                recipeDAO.deleteFavorite(userId, recipeId)
                _isFavorite.value=false
            } else {
                val exists = recipeDAO.exists(recipeId)
                if(!exists) {
                    val firestoreRecipe = repository.getRecipeById(recipeId)
                    firestoreRecipe?.let {
                        recipeDAO.insertRecipe(it.copy(recipeId=recipeId, userId = userId))
                    }
                }
                recipeDAO.insertFavoriteRecipe(FavoriteRecipe(userId = userId, recipeId = recipeId))
                _isFavorite.value = true
            }

        }
    }

}