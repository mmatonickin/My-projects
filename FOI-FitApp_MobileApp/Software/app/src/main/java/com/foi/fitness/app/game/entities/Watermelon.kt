package com.foi.fitness.app.game.entities

import android.content.Context
import com.foi.fitness.app.R

class Watermelon(context: Context, screenWidth: Int, screenHeight: Int) : FoodItem(context, R.drawable.watermelon, screenWidth, screenHeight) {
    override fun applyEffect(player: Player) {
        player.slowFall()
    }
}