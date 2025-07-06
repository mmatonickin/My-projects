package com.foi.fitness.app.converters

import androidx.room.TypeConverter
import com.foi.fitness.app.models.enums.TrainingType


class TrainingTypeConverter {
    @TypeConverter
    fun fromTrainingType (trainingType: TrainingType): String {
        return trainingType.name
    }
    fun toTrainingType (value: String): TrainingType {
        return TrainingType.valueOf(value)
    }
}