package com.foi.fitness.app.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.PrimaryKey
import androidx.room.TypeConverters
import com.foi.fitness.app.converters.DateConverter
import com.foi.fitness.app.converters.TrainingTypeConverter
import com.foi.fitness.app.models.enums.TrainingType
import java.util.Date

@TypeConverters(TrainingTypeConverter::class, DateConverter::class)
@Entity(tableName = "Trainings", foreignKeys = [
    ForeignKey(
        entity = User::class,
        parentColumns = ["user_id"],
        childColumns = ["user_id"],
        onDelete = ForeignKey.CASCADE
    )
],
)
data class Training(
    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "training_id")
    val trainingId: Int,
    @ColumnInfo(name = "training_type") val trainingType: TrainingType,
    @ColumnInfo(name ="training_date") val trainingDate: Date,
    var completed: Boolean,
    @ColumnInfo(name = "user_id", index = true) val userId: Int

)
