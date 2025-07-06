package com.foi.fitness.app.game.entities

import android.content.Context
import android.graphics.*
import android.graphics.Typeface
import androidx.core.content.res.ResourcesCompat
import com.foi.fitness.app.R
import com.foi.fitness.app.game.score.ScoreManager

class GameUI(context: Context) {

    var showStart = true
    var showGameOver = false

    private val gameOverTxt = "GAME OVER"
    private val startButtonRect = RectF(0f, 0f, 0f, 0f)
    private val exitButtonRect = RectF(0f, 0f, 0f, 0f)
    private val restartButtonRect = RectF(0f, 0f, 0f, 0f)

    private var scoreManager: ScoreManager? = null

    private val paint = Paint().apply {
        isAntiAlias = true
        textSize = 60f
        textAlign = Paint.Align.CENTER
    }

    private val customFont: Typeface? = ResourcesCompat.getFont(context, R.font.custom_font)

    fun draw(canvas: Canvas) {
        drawCurrentScore(canvas)

        when {
            showStart -> drawStartMenu(canvas)
            showGameOver -> {
                drawGameOver(canvas)
                drawGameOverMenu(canvas)
            }
        }
    }

    private fun drawStartMenu(canvas: Canvas) {
        val baseY = canvas.height * 0.5f
        val spacing = canvas.height * 0.12f

        drawButton(canvas, "START", startButtonRect, baseY, customFont)
        drawButton(canvas, "EXIT", exitButtonRect, baseY + spacing, customFont)
    }

    private fun drawGameOverMenu(canvas: Canvas) {
        val baseY = canvas.height * 0.5f
        val spacing = canvas.height * 0.12f

        drawButton(canvas, "RESTART", restartButtonRect, baseY, customFont)
        drawButton(canvas, "EXIT", exitButtonRect, baseY + spacing, customFont)
    }

    private fun drawCurrentScore(canvas: Canvas) {
        scoreManager?.let {
            paint.color = Color.WHITE
            paint.textSize = canvas.height * 0.04f
            paint.textAlign = Paint.Align.LEFT
            paint.typeface = customFont
            canvas.drawText("SCORE: ${it.currentScore}", 40f, canvas.height * 0.06f, paint)
        }
    }

    private fun drawGameOver(canvas: Canvas) {
        val centerX = canvas.width / 2f
        val centerY = canvas.height * 0.2f

        paint.color = Color.RED
        paint.textSize = canvas.height * 0.06f
        paint.textAlign = Paint.Align.CENTER
        paint.typeface = customFont
        canvas.drawText(gameOverTxt, centerX, centerY, paint)

        scoreManager?.let {
            paint.color = Color.WHITE
            paint.textSize = canvas.height * 0.045f
            canvas.drawText("Current score: ${it.currentScore}", centerX, centerY + canvas.height * 0.06f, paint)
            canvas.drawText("Best score: ${it.bestScore}", centerX, centerY + canvas.height * 0.11f, paint)
        }
    }

    private fun drawButton(canvas: Canvas, text: String, rect: RectF, offsetY: Float, typeface: Typeface?) {
        typeface?.let { paint.typeface = it }

        val cx = canvas.width / 2f
        val cy = offsetY

        val textSize = canvas.height * 0.045f
        paint.textSize = textSize
        val textWidth = paint.measureText(text)
        val textHeight = paint.fontMetrics.bottom - paint.fontMetrics.top

        val paddingX = canvas.width * 0.06f
        val paddingY = canvas.height * 0.03f

        val rectLeft = cx - textWidth / 2 - paddingX
        val rectTop = cy - textHeight / 2 - paddingY
        val rectRight = cx + textWidth / 2 + paddingX
        val rectBottom = cy + textHeight / 2 + paddingY

        rect.set(rectLeft, rectTop, rectRight, rectBottom)

        paint.color = Color.argb(100, 0, 0, 0)
        canvas.drawRoundRect(rect, 25f, 25f, paint)

        paint.color = Color.WHITE
        paint.textAlign = Paint.Align.CENTER
        val textY = rect.centerY() - (paint.fontMetrics.ascent + paint.fontMetrics.descent) / 2
        canvas.drawText(text, cx, textY, paint)
    }

    fun handleTouch(x: Float, y: Float): UIEvent? {
        return when {
            showStart && startButtonRect.contains(x, y) -> {
                showStart = false
                UIEvent.StartGame
            }
            showGameOver && restartButtonRect.contains(x, y) -> {
                showGameOver = false
                UIEvent.RestartGame
            }
            exitButtonRect.contains(x, y) -> {
                UIEvent.ExitGame
            }
            else -> null
        }
    }

    sealed class UIEvent {
        object StartGame : UIEvent()
        object RestartGame : UIEvent()
        object ExitGame : UIEvent()
    }

    fun setScoreManager(manager: ScoreManager) {
        this.scoreManager = manager
    }
}