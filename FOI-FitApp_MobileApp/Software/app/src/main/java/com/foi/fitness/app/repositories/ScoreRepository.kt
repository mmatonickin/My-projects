package com.foi.fitness.app.repositories

import com.foi.fitness.app.models.ScoreEntry
import com.google.firebase.firestore.FirebaseFirestore
import com.google.firebase.firestore.Query
import kotlinx.coroutines.tasks.await

class ScoreRepository {

    private val db = FirebaseFirestore.getInstance()
    private val scoresCollection = db.collection("scores")

    suspend fun getTopScores(limit: Int = 10): List<ScoreEntry> {
        return try {
            scoresCollection
                .orderBy("score", Query.Direction.DESCENDING)
                .limit(limit.toLong())
                .get()
                .await()
                .toObjects(ScoreEntry::class.java)
        } catch (e: Exception) {
            e.printStackTrace()
            emptyList()
        }
    }

    suspend fun getBestScoreForUser(userId: String): Int {
        return try {
            val snapshot = scoresCollection
                .whereEqualTo("userId", userId)
                .orderBy("score", Query.Direction.DESCENDING)
                .limit(1)
                .get()
                .await()

            val entry = snapshot.documents.firstOrNull()?.toObject(ScoreEntry::class.java)
            entry?.score ?: 0
        } catch (e: Exception) {
            e.printStackTrace()
            0
        }
    }

    suspend fun updateBestScoreForUser(userId: String, newScore: Int, username: String) {
        try {
            val bestScore = getBestScoreForUser(userId)
            if (newScore > bestScore) {
                val newEntry = ScoreEntry(
                    userId = userId,
                    username = username,
                    score = newScore
                )
                scoresCollection.add(newEntry).await()
            }
        } catch (e: Exception) {
            e.printStackTrace()
        }
    }
}