package com.foi.fitness.app.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.PrimaryKey

@Entity(tableName = "Recipes", foreignKeys = [
    ForeignKey(
        entity = User::class,
        parentColumns = ["user_id"],
        childColumns = ["user_id"],
        onDelete = ForeignKey.CASCADE
    )
])
data class Recipe(
    @PrimaryKey val recipeId: String,
    val ingredients: String,
    val procedure: String,
    val calories: Int,
    @ColumnInfo(name = "recipe_name") val recipeName: String,
    @ColumnInfo(name = "user_id", index = true) val userId: Int,
    val imageUri: String?
)
