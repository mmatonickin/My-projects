package com.foi.fitness.app.models

import com.google.firebase.firestore.PropertyName

data class ScoreEntry(
    @get:PropertyName("userId") @set:PropertyName("userId")
    var userId: String = "",

    @get:PropertyName("username") @set:PropertyName("username")
    var username: String = "",

    @get:PropertyName("score") @set:PropertyName("score")
    var score: Int = 0,

    @get:PropertyName("timestamp") @set:PropertyName("timestamp")
    var timestamp: Long = System.currentTimeMillis()
)