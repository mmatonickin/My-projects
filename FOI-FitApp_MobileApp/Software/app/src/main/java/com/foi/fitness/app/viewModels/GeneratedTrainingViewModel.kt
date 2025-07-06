package com.foi.fitness.app.viewModels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.foi.fitness.app.database.DAO.UserDAO
import com.foi.fitness.app.entities.GeneratedTraining
import com.foi.fitness.app.repositories.GeneratedTrainingRepository
import com.foi.fitness.app.repositories.UserRepository
import com.foi.fitness.app.utils.toGenre
import kotlinx.coroutines.launch

class GeneratedTrainingViewModel(private val userDAO: UserDAO): ViewModel() {

    private val userRepository = UserRepository(userDAO)
    private val generatedTrainingRepository = GeneratedTrainingRepository()

    private val _trainingGoals = MutableLiveData<List<String>>()
    val trainingGoals: LiveData<List<String>> = _trainingGoals

    private val _trainingResult = MutableLiveData<GeneratedTraining?>()
    val trainingResult: LiveData<GeneratedTraining?> = _trainingResult

    init {
        loadGoals()
    }

    private fun loadGoals() {
        viewModelScope.launch {
            val goals = generatedTrainingRepository.loadGoals()
            _trainingGoals.value = goals
        }
    }
    fun loadAdequateTrainingForUser(userId: Int, selectedGoal: String, selectedType: String) {
        viewModelScope.launch {
            val user = userRepository.getAllUsers().find { it.userId == userId }

            if (user != null) {
                try {
                    val generatedTraining = generatedTrainingRepository.getTrainings()
                    val matchedTraining = generatedTraining.firstOrNull {
                        val firestoreGenre = it.genre.toGenre()

                        user.age in it.minAge..it.maxAge &&
                        user.height in it.minHeight..it.maxHeight &&
                        user.weight in it.minWeight..it.maxWeight &&
                        it.goal.equals(selectedGoal, ignoreCase = true) &&
                        it.type.equals(selectedType, ignoreCase = true) &&
                        user.genre == firestoreGenre
                    }
                    _trainingResult.postValue(matchedTraining)
                } catch (e: Exception) {
                    _trainingResult.postValue(null)
                }
            }

        }
    }
}