package com.foi.fitness.app.repositories

import com.foi.fitness.app.database.DAO.TrainingDAO
import com.foi.fitness.app.entities.Training

class TrainingRepository(private val trainingDAO: TrainingDAO) {

    suspend fun saveTraining(training: Training) {
        trainingDAO.insertTraining(training)
    }

    suspend fun getUserTrainings(userId: Int): List<Training> {
        return trainingDAO.getTrainingsForUser(userId)
    }
}