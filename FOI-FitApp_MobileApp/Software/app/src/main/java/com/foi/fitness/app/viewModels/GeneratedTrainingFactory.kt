package com.foi.fitness.app.viewModels

import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.foi.fitness.app.database.DAO.UserDAO

class GeneratedTrainingFactory(
    private val userDAO: UserDAO
): ViewModelProvider.Factory {

    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if(modelClass.isAssignableFrom(GeneratedTrainingViewModel::class.java)){
            @Suppress("UNCHECKED_CAST")
            return GeneratedTrainingViewModel(userDAO) as T
        }
        throw IllegalArgumentException("Unknown viewmodel class:${modelClass.name}")
    }
}