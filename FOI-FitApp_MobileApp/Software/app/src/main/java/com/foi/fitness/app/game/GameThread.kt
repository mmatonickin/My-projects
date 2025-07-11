package com.foi.fitness.app.game

import android.graphics.Canvas
import android.view.SurfaceHolder

class GameThread(
    private val surfaceHolder: SurfaceHolder,
    private val gameView: GameView,
): Thread() {

    private var running: Boolean = false
    private val targetFPS = 60

    fun setRunning(isRunning:Boolean){
        running = isRunning
    }

    override fun run() {
        var startTime: Long
        var timeMillis: Long
        var  waitTime: Long
        val targetTime = (1000 / targetFPS).toLong()

        while (running){
            startTime=System.nanoTime()
            var canvas: Canvas? = null

            try {
                canvas = surfaceHolder.lockCanvas()
                synchronized(surfaceHolder){
                    gameView.update()
                    gameView.draw(canvas)
                }
            }catch (e: Exception){
                e.printStackTrace()
            }finally {
                canvas?.let {
                    surfaceHolder.unlockCanvasAndPost(it)
                }
            }

            timeMillis = (System.nanoTime()-startTime) / 1000000
            waitTime = targetTime - timeMillis
            if(waitTime > 0){
                sleep(waitTime)
            }
        }
    }
}