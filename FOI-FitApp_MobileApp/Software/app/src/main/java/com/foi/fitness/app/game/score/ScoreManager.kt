package com.foi.fitness.app.game.score

class ScoreManager {

    var currentScore: Int = 0
        private set

    var bestScore: Int = 0
        private set

    fun increaseScore(amount: Int) {
        currentScore += amount
    }

    fun decreaseScore(amount: Int) {
        currentScore = (currentScore - amount).coerceAtLeast(0)
    }

    fun reset() {
        currentScore = 0
    }

    fun updateBestScoreIfNeeded() {
        if (currentScore > bestScore) {
            bestScore = currentScore
        }
    }

    fun setBestScore(value: Int) {
        bestScore = value
    }
}
