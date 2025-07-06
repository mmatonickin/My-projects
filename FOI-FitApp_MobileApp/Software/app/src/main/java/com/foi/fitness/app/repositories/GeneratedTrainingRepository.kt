package com.foi.fitness.app.repositories

import android.util.Log
import com.foi.fitness.app.entities.GeneratedTraining
import com.foi.fitness.app.entities.Recipe
import com.google.firebase.firestore.FirebaseFirestore
import kotlinx.coroutines.tasks.await


class GeneratedTrainingRepository {

    private val db = FirebaseFirestore.getInstance()

    suspend fun getTrainings(): List<GeneratedTraining>{
        return try {
            val snapshot = db.collection("trainings").get().await()
            snapshot.documents.mapNotNull {
                it.toObject(GeneratedTraining::class.java)}
            } catch (e: Exception) {
                emptyList()
        }
    }

    suspend fun loadGoals(): List<String> {
        return try {
            val snapshot = db.collection("trainings").get().await()
            snapshot.mapNotNull { it.getString("goal") }
                .distinct()
                .sorted()
        } catch (e: Exception) {
            emptyList()
        }
    }
}