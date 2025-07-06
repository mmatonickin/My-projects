package com.foi.fitness.app.converters

import androidx.room.TypeConverter
import com.foi.fitness.app.models.enums.TrainingGoal

class TrainingGoalConverter {
    @TypeConverter
    fun fromTrainingGoal (trainingGoal: TrainingGoal): String {
        return trainingGoal.name
    }
    @TypeConverter
    fun toTrainingGoal (value: String): TrainingGoal {
        return TrainingGoal.valueOf(value)
    }
}