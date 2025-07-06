package com.foi.fitness.app.viewModels

import androidx.lifecycle.LiveData
import androidx.lifecycle.ViewModel
import com.foi.fitness.app.entities.Recipe
import com.foi.fitness.app.repositories.RecipeRepository

class FavoriteRecipesViewModel(
    private val recipeRepository: RecipeRepository
): ViewModel() {

    fun loadFavoriteRecipes(userId: Int): LiveData<List<Recipe>> {
        return recipeRepository.getFavoriteRecipesLive(userId)
    }
}