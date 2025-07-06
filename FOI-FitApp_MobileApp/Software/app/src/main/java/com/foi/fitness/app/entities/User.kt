package com.foi.fitness.app.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import androidx.room.TypeConverters
import com.foi.fitness.app.converters.GenreConverter
import com.foi.fitness.app.models.enums.Genre


@Entity(tableName = "Users")
@TypeConverters(GenreConverter::class)
data class User(
    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "user_id")
    val userId: Int,
    val name: String,
    val surname: String,
    val weight: Int,
    val height: Int,
    val age: Int,
    val genre: Genre,
    val email: String,
    val username: String,
    val password: String,
    val highScore: Int? = null

)
