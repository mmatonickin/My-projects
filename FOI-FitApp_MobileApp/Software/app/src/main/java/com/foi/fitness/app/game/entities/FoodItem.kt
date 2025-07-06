package com.foi.fitness.app.game.entities

import android.content.Context
import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.graphics.Canvas
import com.foi.fitness.app.R
import android.graphics.RectF

abstract class FoodItem(
    context: Context,
    resId: Int,
    screenWidth: Int,
    screenHeight: Int
) {
    var x: Float = 0f
    var y: Float = 0f

    val width = (screenWidth * 0.04f).toInt()
    val height = (screenHeight * 0.08f).toInt()

    val bitmap: Bitmap = Bitmap.createScaledBitmap(
        BitmapFactory.decodeResource(context.resources, resId),
        width,
        height,
        false
    )

    open fun update(speedMultiplier: Int = 0) {
        x -= 10f + speedMultiplier
    }

    open fun draw(canvas: Canvas) {
        canvas.drawBitmap(bitmap, x, y, null)
    }

    fun getBoundingBox(): RectF {
        return RectF(x, y, x + width, y + height)
    }

    abstract fun applyEffect(player: Player)
}