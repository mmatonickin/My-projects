package com.foi.fitness.app.database.DAO

import androidx.room.Dao
import androidx.room.Insert
import androidx.room.Query
import com.foi.fitness.app.entities.Training

@Dao
interface TrainingDAO {

    @Insert
    suspend fun insertTraining(training: Training)

    @Query("SELECT * FROM Trainings WHERE user_id = :userId")
    suspend fun getTrainingsForUser(userId: Int): List<Training>
}