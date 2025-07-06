package com.foi.fitness.app.game.entities

import android.content.Context
import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.graphics.Canvas
import android.graphics.RectF
import com.foi.fitness.app.R

class Player(
    context: Context,
    private val screenWidth: Int,
    private val screenHeight: Int
) {
    private val playerSpriteWidth = (screenWidth * 0.05f).toInt()
    private val playerSpriteHeight = (screenHeight * 0.15f).toInt()

    private val startX = screenWidth * 0.05f
    private val startY = screenHeight / 2f - playerSpriteHeight / 2f

    var x = startX
    var y = startY

    private val bitmap: Bitmap = Bitmap.createScaledBitmap(
        BitmapFactory.decodeResource(context.resources, R.drawable.character),
        playerSpriteWidth,
        playerSpriteHeight,
        false
    )

    private var velocityY = 0f
    private val gravity = screenHeight * 0.002f
    private val jumpForce = -screenHeight * 0.02f
    private val maxFallSpeed = screenHeight * 0.025f

    private var gravityModifier = 1.0f
    private var effectEndTime: Long = 0

    fun update() {
        if (System.currentTimeMillis() > effectEndTime) {
            gravityModifier = 1.0f
        }

        velocityY += gravity * gravityModifier
        if (velocityY > maxFallSpeed) velocityY = maxFallSpeed
        y += velocityY
    }

    fun jump() {
        velocityY = jumpForce
        gravityModifier = 1.0f
    }

    fun draw(canvas: Canvas) {
        canvas.drawBitmap(bitmap, x, y, null)
    }

    fun reset() {
        x = startX
        y = startY
        velocityY = 0f
        gravityModifier = 1.0f
        effectEndTime = 0
    }

    fun slowFall() {
        gravityModifier = 0.85f
        effectEndTime = System.currentTimeMillis() + 3000
    }

    fun fastFall() {
        gravityModifier = 1.3f
        effectEndTime = System.currentTimeMillis() + 3000
    }

    fun getBoundingBox(): RectF = RectF(x, y, x + playerSpriteWidth, y + playerSpriteHeight)
    fun getBottom(): Float = y + playerSpriteHeight
    fun getTop(): Float = y
}