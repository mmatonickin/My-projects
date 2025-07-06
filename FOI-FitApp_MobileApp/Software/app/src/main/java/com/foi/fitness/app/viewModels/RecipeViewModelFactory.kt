package com.foi.fitness.app.viewModels

import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.foi.fitness.app.database.DAO.RecipeDAO

class RecipeViewModelFactory(
    private val recipeDao: RecipeDAO
) : ViewModelProvider.Factory {

    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(RecipeViewModel::class.java)) {
            @Suppress("UNCHECKED_CAST")
            return RecipeViewModel(recipeDao) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}
