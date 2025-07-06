package com.foi.fitness.app

import android.os.Bundle
import android.view.MotionEvent
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.lifecycleScope
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.game.GameView
import com.foi.fitness.app.game.entities.GameUI.UIEvent.*
import com.foi.fitness.app.repositories.ScoreRepository
import com.foi.fitness.app.utils.SharedPreferencesManager
import com.foi.fitness.app.viewModels.ScoreViewModel
import com.foi.fitness.app.viewModels.ScoreViewModelFactory
import com.foi.fitness.app.game.score.ScoreManager
import kotlinx.coroutines.launch

class GameActivity : AppCompatActivity() {

    private lateinit var gameView: GameView
    private lateinit var scoreViewModel: ScoreViewModel

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        AppDatabase.buildInstance(applicationContext)
        val userDAO = AppDatabase.getInstance().getUsersDao()
        scoreViewModel = ViewModelProvider(this, ScoreViewModelFactory(userDAO))[ScoreViewModel::class.java]

        val scoreManager = ScoreManager()
        val userId = SharedPreferencesManager.getInstance(applicationContext).getUserId()

        if (userId != null) {
            val repository = ScoreRepository()
            lifecycleScope.launch {
                val bestScore = repository.getBestScoreForUser(userId.toString())
                scoreManager.setBestScore(bestScore)

                gameView = GameView(this@GameActivity, scoreManager)

                gameView.gameOverListener = object : GameView.GameOverListener {
                    override fun onGameOver(finalScore: Int) {
                        val id = SharedPreferencesManager.getInstance(applicationContext).getUserId()
                        if (id != null) {
                            scoreViewModel.saveScore(id, finalScore)
                        }
                    }
                }

                setContentView(gameView)
            }
        }
    }

    override fun onTouchEvent(event: MotionEvent?): Boolean {
        event?.let {
            if (it.action == MotionEvent.ACTION_DOWN) {
                when (val uiEvent = gameView.handleTouch(it.x, it.y)) {
                    is StartGame,
                    is RestartGame -> gameView.resetGame()
                    is ExitGame -> finish()
                    null -> {}
                }
            }
        }
        return super.onTouchEvent(event)
    }
}