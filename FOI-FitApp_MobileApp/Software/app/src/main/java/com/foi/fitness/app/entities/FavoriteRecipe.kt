package com.foi.fitness.app.entities

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.ForeignKey
import androidx.room.Index


@Entity(
    tableName = "Favorite_recipes",
    primaryKeys = ["recipe_id", "user_id"],
    foreignKeys = [
        ForeignKey(
            entity = Recipe::class,
            parentColumns = ["recipeId"],
            childColumns = ["recipe_id"],
            onDelete = ForeignKey.CASCADE
        ),
        ForeignKey(
            entity = User::class,
            parentColumns = ["user_id"],
            childColumns = ["user_id"],
            onDelete = ForeignKey.CASCADE
        )
    ],
    indices = [
        Index(value = ["recipe_id"]),
        Index(value = ["user_id"])
    ]
    )

data class FavoriteRecipe(
    @ColumnInfo(name = "recipe_id")
    val recipeId: String,
    @ColumnInfo(name="user_id")
    val userId: Int
)
