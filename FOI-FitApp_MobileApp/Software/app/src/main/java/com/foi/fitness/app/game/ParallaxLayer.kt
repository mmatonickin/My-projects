package com.foi.fitness.app.game

import android.content.Context
import android.content.res.Resources
import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.graphics.Canvas

class ParallaxLayer(
    context: Context,
    resId: Int,
    private val scrollSpeed: Float,
    private val alignBottom: Boolean = false
) {
    private var bitmap: Bitmap
    private var x1 = 0f
    private var x2 = 0f
    private var drawY= 0f

    private var speedMultiplier = 1.0f

    init {
        val original = BitmapFactory.decodeResource(context.resources, resId)

        val screenWidth = Resources.getSystem().displayMetrics.widthPixels
        val scaledHeight = original.height
        val scaledWidth = screenWidth

        bitmap = Bitmap.createScaledBitmap(original, scaledWidth, scaledHeight, false)

        drawY = if (alignBottom) {
            context.resources.displayMetrics.heightPixels - bitmap.height.toFloat()
        } else {
            0f
        }

        x1 = 0f
        x2 = bitmap.width.toFloat()
    }

    fun update() {
        val effectiveSpeed = scrollSpeed * speedMultiplier

        x1 -= effectiveSpeed
        x2 -= effectiveSpeed

        if (x1 + bitmap.width < 0) {
            x1 = x2 + bitmap.width
        }
        if (x2 + bitmap.width < 0) {
            x2 = x1 + bitmap.width
        }
    }

    fun draw(canvas: Canvas) {
        canvas.drawBitmap(bitmap, x1, drawY, null)
        canvas.drawBitmap(bitmap, x2, drawY, null)
    }

    fun setSpeedMultiplier(multiplier: Float) {
        speedMultiplier = multiplier
    }
}