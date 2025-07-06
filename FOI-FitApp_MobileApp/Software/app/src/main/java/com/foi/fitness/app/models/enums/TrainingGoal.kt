package com.foi.fitness.app.models.enums

enum class TrainingGoal(val label: String) {
    WeightLoss("Weight loss"),
    EnduranceImprovement("Endurance improvement");

    override fun toString(): String = label
}