package com.foi.fitness.app.game

import android.app.Activity
import android.content.Context
import android.graphics.Canvas
import android.graphics.Color
import android.view.MotionEvent
import android.view.SurfaceHolder
import android.view.SurfaceView
import com.foi.fitness.app.game.entities.*
import com.foi.fitness.app.game.entities.GameUI.UIEvent.*
import com.foi.fitness.app.game.score.ScoreManager

class GameView(context: Context, private val scoreManager: ScoreManager) : SurfaceView(context), SurfaceHolder.Callback {

    private var gameThread: GameThread
    private lateinit var background: ParallaxBackground
    private lateinit var player: Player
    var gameOverListener: GameOverListener? = null

    private var screenHeight = 0
    private var screenWidth = 0
    private var SPAWN_OFFSET = 0f

    private val gameUI = GameUI(context).apply {
        setScoreManager(scoreManager)
    }
    private val foodItems = mutableListOf<FoodItem>()
    private val obstacles = mutableListOf<Obstacle>()

    private var spawnInterval = 2500L
    private val minSpawnInterval = 800L
    private val difficultyIncreaseRate = 20000L

    private var blockSpawnInterval = 3000L
    private val minBlockInterval = 600L

    private var startTime = System.currentTimeMillis()
    private var lastFoodSpawnTime = System.currentTimeMillis()
    private var lastBlockSpawnTime = System.currentTimeMillis()
    private var backgroundSpeedEndTime: Long = 0L

    private var difficultyLevel = 0

    private val maxFoodPerLevel = 2
    private val maxTotalFood = 10
    private val maxBlockPerLevel = 3
    private val maxTotalBlocks = 15

    init {
        holder.addCallback(this)
        gameThread = GameThread(holder, this)
        isFocusable = true
    }

    override fun surfaceCreated(holder: SurfaceHolder) {
        screenWidth = width
        screenHeight = height
        SPAWN_OFFSET = screenWidth * 0.05f

        background = ParallaxBackground(context)
        player = Player(context, screenWidth, screenHeight)

        gameThread.setRunning(true)
        gameThread.start()
    }

    override fun surfaceChanged(holder: SurfaceHolder, format: Int, width: Int, height: Int) {}

    override fun surfaceDestroyed(holder: SurfaceHolder) {
        gameThread.setRunning(false)
        while (true) {
            try {
                gameThread.join()
                break
            } catch (e: InterruptedException) {
                e.printStackTrace()
            }
        }
    }

    fun update() {
        if (gameUI.showStart || gameUI.showGameOver) return

        updateGameObjects()
        handleFoodCollisions()
        handleObstacleCollisions()
        spawnElementsIfNeeded()
        checkGameOverByBounds()
        restoreBackgroundSpeedIfNeeded()
    }

    override fun draw(canvas: Canvas) {
        super.draw(canvas)
        canvas.drawColor(Color.rgb(135, 206, 235))
        background.draw(canvas)
        player.draw(canvas)
        foodItems.forEach { it.draw(canvas) }
        obstacles.forEach { it.draw(canvas) }
        gameUI.draw(canvas)
    }

    override fun onTouchEvent(event: MotionEvent?): Boolean {
        event?.let {
            if (it.action == MotionEvent.ACTION_DOWN) {
                when (val uiEvent = gameUI.handleTouch(it.x, it.y)) {
                    is StartGame -> {
                        player.reset()
                        scoreManager.reset()
                    }
                    is RestartGame -> {
                        player.reset()
                        scoreManager.reset()
                        gameUI.showGameOver = false
                        gameUI.showStart = false
                        if (!gameThread.isAlive) {
                            gameThread = GameThread(holder, this)
                            gameThread.setRunning(true)
                            gameThread.start()
                        }
                    }
                    is ExitGame -> {
                        (context as? Activity)?.finish()
                    }
                    null -> {
                        if (!gameUI.showGameOver && !gameUI.showStart) player.jump()
                    }
                }
            }
        }
        return true
    }

    private fun updateGameObjects() {
        background.update()
        player.update()
        foodItems.forEach { it.update(difficultyLevel) }
        foodItems.removeAll { it.x + it.width < 0 }
        obstacles.forEach { it.update(difficultyLevel) }
        obstacles.removeAll { it.x + it.width < 0 }
    }

    private fun handleFoodCollisions() {
        val iterator = foodItems.iterator()
        while (iterator.hasNext()) {
            val item = iterator.next()
            if (item.getBoundingBox().intersect(player.getBoundingBox())) {
                applyFoodEffect(item)
                iterator.remove()
            }
        }
    }

    private fun handleObstacleCollisions() {
        val iterator = obstacles.iterator()
        while (iterator.hasNext()) {
            val obstacle = iterator.next()
            if (obstacle.getBoundingBox().intersect(player.getBoundingBox())) {
                iterator.remove()
                scoreManager.updateBestScoreIfNeeded()
                gameUI.showGameOver = true
                gameThread.setRunning(false)
                gameOverListener?.onGameOver(scoreManager.currentScore)
                break
            }
        }
    }

    private fun spawnElementsIfNeeded() {
        adjustDifficulty()
        val currentTime = System.currentTimeMillis()

        val maxFoodToSpawn = minOf(maxTotalFood, maxFoodPerLevel + difficultyLevel)
        val maxBlockToSpawn = minOf(maxTotalBlocks, maxBlockPerLevel + difficultyLevel)

        if (currentTime - lastFoodSpawnTime > spawnInterval && foodItems.size < maxFoodToSpawn) {
            val foodToSpawn = (1..(maxFoodToSpawn - foodItems.size).coerceAtMost(3)).random()
            repeat(foodToSpawn) { spawnRandomFood() }
            lastFoodSpawnTime = currentTime
        }

        if (currentTime - lastBlockSpawnTime > blockSpawnInterval && obstacles.size < maxBlockToSpawn) {
            spawnObstacle()
            lastBlockSpawnTime = currentTime
        }
    }

    private fun spawnRandomFood() {
        val occupiedY = getOccupiedYRanges()
        repeat(10) {
            val newFood = when ((1..6).random()) {
                1 -> Apple(context, screenWidth, screenHeight)
                2 -> Cake(context, screenWidth, screenHeight)
                3 -> CakeStrawberry(context, screenWidth, screenHeight)
                4 -> Carrot(context, screenWidth, screenHeight)
                5 -> IceCream(context, screenWidth, screenHeight)
                else -> Watermelon(context, screenWidth, screenHeight)
            }

            val verticalPadding = (screenHeight * 0.05f).toInt()
            val maxY = screenHeight - newFood.height - verticalPadding
            val minY = verticalPadding
            val randomY = (minY..maxY).random().toFloat()
            if (!isOverlappingAny(randomY, randomY + newFood.height, occupiedY)) {
                newFood.x = screenWidth + SPAWN_OFFSET
                newFood.y = randomY
                foodItems.add(newFood)
                return
            }
        }
    }

    private fun spawnObstacle() {
        val occupiedY = getOccupiedYRanges()
        repeat(10) {
            val block = Block(context, screenWidth, screenHeight).apply {
                val verticalPadding = (screenHeight * 0.05f).toInt()
                val maxY = screenHeight - height - verticalPadding
                val minY = verticalPadding
                val blockY = (minY..maxY).random().toFloat()
                if (!isOverlappingAny(blockY, blockY + height, occupiedY)) {
                    x = screenWidth + SPAWN_OFFSET
                    y = blockY
                    obstacles.add(this)
                    return
                }
            }
        }
    }

    private fun applyFoodEffect(item: FoodItem) {
        when (item) {
            is Cake, is IceCream, is CakeStrawberry -> {
                player.slowFall()
                background.setSpeedMultiplier(0.2f)
                backgroundSpeedEndTime = System.currentTimeMillis() + 5000
                scoreManager.decreaseScore(5)
            }
            is Carrot, is Apple, is Watermelon -> {
                player.fastFall()
                background.setSpeedMultiplier(3.0f)
                backgroundSpeedEndTime = System.currentTimeMillis() + 5000
                scoreManager.increaseScore(10)
            }
            else -> item.applyEffect(player)
        }
    }

    private fun checkGameOverByBounds() {
        if (player.getTop() <= 0 || player.getBottom() >= screenHeight) {
            scoreManager.updateBestScoreIfNeeded()
            gameUI.showGameOver = true
            gameOverListener?.onGameOver(scoreManager.currentScore)
            gameThread.setRunning(false)
        }
    }

    private fun restoreBackgroundSpeedIfNeeded() {
        if (System.currentTimeMillis() > backgroundSpeedEndTime) {
            background.setSpeedMultiplier(1.0f)
        }
    }

    private fun getOccupiedYRanges(): List<Pair<Float, Float>> {
        return foodItems.map { it.y to (it.y + it.height) } +
                obstacles.map { it.y to (it.y + it.height) }
    }

    private fun isOverlappingAny(top: Float, bottom: Float, ranges: List<Pair<Float, Float>>): Boolean {
        return ranges.any { (rTop, rBottom) -> bottom >= rTop && top <= rBottom }
    }

    private fun adjustDifficulty() {
        val elapsedTime = System.currentTimeMillis() - startTime
        val steps = (elapsedTime / difficultyIncreaseRate).toInt()

        spawnInterval = (5000L - steps * 500L).coerceAtLeast(minSpawnInterval)
        blockSpawnInterval = (1800L - steps * 300L).coerceAtLeast(minBlockInterval)
        difficultyLevel = steps
    }

    fun handleTouch(x: Float, y: Float): GameUI.UIEvent? {
        return gameUI.handleTouch(x, y)
    }

    fun resetGame() {
        player.reset()
        scoreManager.reset()
        foodItems.clear()
        obstacles.clear()
        gameUI.showGameOver = false
        gameUI.showStart = false

        if (gameThread.isAlive) {
            gameThread.setRunning(false)
            try {
                gameThread.join()
            } catch (e: InterruptedException) {
                e.printStackTrace()
            }
        }

        gameThread = GameThread(holder, this)
        gameThread.setRunning(true)
        gameThread.start()
    }

    interface GameOverListener {
        fun onGameOver(finalScore: Int)
    }
}