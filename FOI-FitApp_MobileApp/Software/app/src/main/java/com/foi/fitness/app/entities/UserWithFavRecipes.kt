package com.foi.fitness.app.entities

import androidx.room.Embedded
import androidx.room.Junction
import androidx.room.Relation

data class UserWithFavRecipes(
    @Embedded val user: User,

    @Relation(
        parentColumn = "user_id",
        entityColumn = "recipeId",
        associateBy = Junction(
            value = FavoriteRecipe::class,
            parentColumn = "user_id",
            entityColumn = "recipe_id"
        )
    )
    val favoriteRecipes: List<Recipe>
)
