package com.foi.fitness.app.database

import android.content.Context
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import androidx.room.TypeConverters
import com.foi.fitness.app.converters.DateConverter
import com.foi.fitness.app.converters.GenreConverter
import com.foi.fitness.app.converters.TrainingGoalConverter
import com.foi.fitness.app.converters.TrainingTypeConverter
import com.foi.fitness.app.database.DAO.RecipeDAO
import com.foi.fitness.app.database.DAO.TrainingDAO
import com.foi.fitness.app.database.DAO.UserDAO
import com.foi.fitness.app.entities.FavoriteRecipe
import com.foi.fitness.app.entities.Recipe
import com.foi.fitness.app.entities.Training
import com.foi.fitness.app.entities.TrainingPlan
import com.foi.fitness.app.entities.User


@Database(version = 2, exportSchema = false, entities = [
    User::class,
    TrainingPlan::class,
    Training::class,
    Recipe::class,
    FavoriteRecipe::class
])
@TypeConverters(
    DateConverter::class,
    GenreConverter::class,
    TrainingGoalConverter::class,
    TrainingTypeConverter::class
)
abstract class AppDatabase: RoomDatabase() {
    abstract fun getUsersDao(): UserDAO
    abstract fun getTrainingDao(): TrainingDAO
    abstract fun getRecipeDao(): RecipeDAO

    companion object {
        private var dbInstance: AppDatabase? = null

        fun getInstance(): AppDatabase {
            if(dbInstance == null)
                throw NullPointerException("Database instance not created")

            return dbInstance!!

        }

        fun buildInstance(context: Context){
            if(dbInstance == null){
                val dbBuilder = Room.databaseBuilder(
                    context,
                    AppDatabase::class.java,
                    "fitApp.db"
                )

                dbBuilder.allowMainThreadQueries()
                dbBuilder.fallbackToDestructiveMigration()

                dbInstance = dbBuilder.build()
            }
        }
    }
}