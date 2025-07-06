package com.foi.fitness.app.game.entities

import android.content.Context
import com.foi.fitness.app.R

class Cake(context: Context, screenWidth: Int, screenHeight: Int) : FoodItem(context, R.drawable.cake, screenWidth, screenHeight) {
    override fun applyEffect(player: Player) {
        player.fastFall()
    }
}
