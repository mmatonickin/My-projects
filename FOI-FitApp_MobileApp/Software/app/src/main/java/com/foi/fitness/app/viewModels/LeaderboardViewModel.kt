package com.foi.fitness.app.viewModels

import com.foi.fitness.app.models.ScoreEntry
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.foi.fitness.app.repositories.ScoreRepository
import kotlinx.coroutines.launch

class LeaderboardViewModel : ViewModel() {

    private val repo = ScoreRepository()

    private val _scores = MutableLiveData<List<ScoreEntry>>()
    val scores: LiveData<List<ScoreEntry>> = _scores

    fun loadTopScores(limit: Int = 10) {
        viewModelScope.launch {
            val topScores = repo.getTopScores(limit)
            _scores.value = topScores
        }
    }
}