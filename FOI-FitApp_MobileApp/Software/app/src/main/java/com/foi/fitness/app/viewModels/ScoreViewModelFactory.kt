package com.foi.fitness.app.viewModels

import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.foi.fitness.app.database.DAO.UserDAO

class ScoreViewModelFactory(private val userDAO: UserDAO) : ViewModelProvider.Factory {
    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(ScoreViewModel::class.java)) {
            @Suppress("UNCHECKED_CAST")
            return ScoreViewModel(userDAO) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}