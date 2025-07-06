package com.foi.fitness.app.viewModels

import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.foi.fitness.app.repositories.RecipeRepository

class FavoriteRecipesViewModelFactory(
    private val repository: RecipeRepository
) : ViewModelProvider.Factory {
    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(FavoriteRecipesViewModel::class.java)) {
            @Suppress("UNCHECKED_CAST")
            return FavoriteRecipesViewModel(repository) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}
