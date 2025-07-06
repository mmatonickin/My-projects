package com.foi.fitness.app.viewModels

import android.util.Log
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.foi.fitness.app.database.DAO.UserDAO
import com.foi.fitness.app.repositories.ScoreRepository
import kotlinx.coroutines.launch

class ScoreViewModel(private val userDAO: UserDAO) : ViewModel() {

    private val repository = ScoreRepository()

    fun saveScore(userId: Int, score: Int) {
        viewModelScope.launch {
            try {
                val user = userDAO.getUserById(userId)
                val username = user?.username ?: "Guest"

                repository.updateBestScoreForUser(
                    userId = userId.toString(),
                    newScore = score,
                    username = username
                )
                Log.d("ScoreViewModel", "Rezultat spremljen: $score za $username")
            } catch (e: Exception) {
                Log.e("ScoreViewModel", "Greška pri spremanju rezultata", e)
            }
        }
    }
}