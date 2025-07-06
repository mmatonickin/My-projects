package com.foi.fitness.app.utils

import com.foi.fitness.app.entities.Recipe

object RecipeInputValidators {

    fun validateRequiredFields(
        recipeName: String,
        ingredients: String,
        procedure: String,
        calories: String
    ): String? {
        return if (
            recipeName.isBlank() ||
            ingredients.isBlank() ||
            procedure.isBlank() ||
            calories.isBlank()
        ) {
            "All fields are required"
        } else null
    }
    fun validateCalories(caloriesStr: String): String? {
        val calories = caloriesStr.toIntOrNull()
        return when {
            calories == null -> "Calories must be a valid number!"
            calories < 250 || calories > 2500 -> "Calories must be between 250 and 2500!"
            else -> null
        }
    }
}