package com.foi.fitness.app.viewModels

import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.foi.fitness.app.entities.Training
import com.foi.fitness.app.repositories.TrainingRepository
import kotlinx.coroutines.launch

class UserTrainingViewModel(private val trainingRepository: TrainingRepository): ViewModel() {

    private val _trainings = MutableLiveData<List<Training>>()
    val trainings: MutableLiveData<List<Training>> get() = _trainings

    fun loadUserTrainings(userId: Int) {
        viewModelScope.launch {
            val userTrainings = trainingRepository.getUserTrainings(userId)
            _trainings.postValue(userTrainings)
        }
    }
}