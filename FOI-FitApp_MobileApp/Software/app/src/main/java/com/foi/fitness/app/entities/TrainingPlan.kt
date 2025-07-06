package com.foi.fitness.app.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import androidx.room.TypeConverters
import com.foi.fitness.app.converters.TrainingGoalConverter
import com.foi.fitness.app.converters.TrainingTypeConverter
import com.foi.fitness.app.models.enums.TrainingGoal
import com.foi.fitness.app.models.enums.TrainingType


@Entity(tableName = "Training_plans")
@TypeConverters(TrainingGoalConverter::class, TrainingTypeConverter::class)
data class TrainingPlan(
    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name="training_plan_id")
    val trainingPlanId: Int,
    @ColumnInfo(name="training_type") val trainingType: TrainingType,
    @ColumnInfo(name="training_goal") val trainingGoal: TrainingGoal,
    val duration: Int,
    val rest: Double,
    val pace: Double,
    val distance: Double

)
