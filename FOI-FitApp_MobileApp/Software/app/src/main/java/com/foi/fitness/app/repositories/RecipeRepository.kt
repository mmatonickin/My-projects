package com.foi.fitness.app.repositories

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.map
import com.foi.fitness.app.database.DAO.RecipeDAO
import com.foi.fitness.app.entities.Recipe
import com.google.firebase.firestore.FirebaseFirestore
import kotlinx.coroutines.tasks.await


class RecipeRepository(private val recipeDao: RecipeDAO?=null) {
    private val db = FirebaseFirestore.getInstance()

    suspend fun getRecipeByCalories(calories: Int): Recipe?{
        return try {
            val lowerBound = calories - 50
            val upperBound = calories + 50

            val snapshot = db.collection("recipes")
                .whereGreaterThanOrEqualTo("calories", lowerBound)
                .whereLessThanOrEqualTo("calories", upperBound)
                .get()
                .await()

            val recipes = snapshot.documents.map { doc ->
                Recipe(
                    recipeId = doc.id,
                    recipeName = doc.getString("recipeName") ?: "",
                    ingredients = doc.getString("ingredients") ?: "",
                    procedure = doc.getString("procedure") ?: "",
                    calories = (doc.getLong("calories") ?: 0L).toInt(),
                    userId = (doc.getLong("userId") ?: 0L).toInt(),
                    imageUri = doc.getString("imageUri")
                )
            }
            if(recipes.isNotEmpty()) recipes.random() else null
        } catch (e: Exception) {
            Log.e("RecipeRepository", "Greška pri dohvaćanju recepta u rasponu kalorija", e)
            null
        }
    }

    suspend fun getRecipes(): List<Recipe> {
        return try {
            val snapshot =
                db.collection("recipes")
                .get()
                .await()

            snapshot.documents.map { doc ->
                Recipe(
                    recipeId = doc.id,
                    recipeName = doc.getString("recipeName") ?: "",
                    ingredients = doc.getString("ingredients") ?: "",
                    procedure = doc.getString("procedure") ?: "",
                    calories = (doc.getLong("calories") ?: 0L).toInt(),
                    userId = (doc.getLong("userId") ?: 0L).toInt(),
                    imageUri = doc.getString("imageUri")
                )
            }
        } catch (e: Exception) {
            Log.e("RecipeRepository", "Error fetching recipes", e)
            emptyList()
        }

    }

    suspend fun insertRecipes(recipe: Recipe): Result<Unit> {
        return try {
            db.collection("recipes")
                .add(recipe)
                .await()
                Result.success(Unit)
        } catch (e: Exception) {
            Result.failure(e)
        }
    }

    suspend fun getRecipeById(recipeId: String): Recipe? {
        return try {
            val doc = db.collection("recipes")
                .document(recipeId)
                .get()
                .await()

            if (doc.exists()) {
                Recipe(
                    recipeId = doc.id,
                    recipeName = doc.getString("recipeName") ?: "",
                    ingredients = doc.getString("ingredients") ?: "",
                    procedure = doc.getString("procedure") ?: "",
                    calories = (doc.getLong("calories") ?: 0L).toInt(),
                    userId = (doc.getLong("userId") ?: 0L).toInt(),
                    imageUri = doc.getString("imageUri")
                )
            } else null
        } catch (e: Exception) {
            null
        }
    }

    fun getFavoriteRecipesLive(userId: Int): LiveData<List<Recipe>> {
        return recipeDao?.getUserWithFavoriteRecipes(userId)
            ?.map { it.favoriteRecipes }
            ?: MutableLiveData(emptyList())
    }
}
