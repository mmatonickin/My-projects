package com.foi.fitness.app.viewModels

import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.foi.fitness.app.repositories.TrainingRepository

class UserTrainingViewModelFactory(
    private val repository: TrainingRepository
): ViewModelProvider.Factory {

    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if(modelClass.isAssignableFrom(UserTrainingViewModel::class.java)){
            @Suppress("UNCHECKED_CAST")
            return UserTrainingViewModel(repository) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}