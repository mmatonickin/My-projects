package com.foi.fitness.app.viewModels

import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.foi.fitness.app.database.DAO.RecipeDAO
import com.foi.fitness.app.repositories.RecipeRepository

class RecipeDetailViewModelFactory(
    private val recipeDAO: RecipeDAO,
    private val repository: RecipeRepository
) : ViewModelProvider.Factory {

    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(RecipeDetailViewModel::class.java)) {
            @Suppress("UNCHECKED_CAST")
            return RecipeDetailViewModel(recipeDAO, repository) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}
