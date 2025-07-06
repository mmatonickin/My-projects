package com.foi.fitness.app.game

import android.content.Context
import android.graphics.Canvas
import com.foi.fitness.app.R

class ParallaxBackground (context: Context){

    private val layer1 = ParallaxLayer(
        context,
        R.drawable.sky1_parallax,
        1.0f,
        alignBottom = true)

    private val layer2 = ParallaxLayer(
        context, R.drawable.sky2_parallax,
        1.5f,
        alignBottom = true)

    fun update(){
        layer1.update()
        layer2.update()
    }

    fun draw(canvas: Canvas){
        layer2.draw(canvas)
        layer1.draw(canvas)
    }

    fun setSpeedMultiplier(multiplier: Float) {
        layer1.setSpeedMultiplier(multiplier)
        layer2.setSpeedMultiplier(multiplier)
    }
}