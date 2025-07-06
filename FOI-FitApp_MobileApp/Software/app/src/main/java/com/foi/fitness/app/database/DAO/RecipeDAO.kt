package com.foi.fitness.app.database.DAO

import androidx.lifecycle.LiveData
import androidx.room.Dao
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import androidx.room.Transaction
import com.foi.fitness.app.entities.FavoriteRecipe
import com.foi.fitness.app.entities.Recipe
import com.foi.fitness.app.entities.UserWithFavRecipes
import kotlinx.coroutines.flow.Flow

@Dao
interface RecipeDAO {
    @Insert
    suspend fun insertRecipe(recipe: Recipe)

    @Query("SELECT * FROM Recipes WHERE user_id = :userId")
    suspend fun getRecipesForUser(userId: Int): List<Recipe>

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insertFavoriteRecipe(favoriteRecipe: FavoriteRecipe)

    @Query("DELETE FROM favorite_recipes WHERE user_id = :userId AND recipe_id = :recipeId")
    suspend fun deleteFavorite(userId: Int, recipeId: String)

    @Query("SELECT EXISTS(SELECT 1 FROM favorite_recipes WHERE user_id = :userId AND recipe_id = :recipeId)")
    suspend fun isFavorite(userId: Int, recipeId: String): Boolean

    @Query("SELECT recipe_id FROM favorite_recipes WHERE user_id = :userId")
    fun getFavoriteRecipeIds(userId: Int): Flow<List<String>>

    @Query("SELECT * FROM recipes WHERE recipeId = :recipeId")
    suspend fun getRecipeById(recipeId: String): Recipe?

    @Query("SELECT EXISTS(SELECT 1 FROM recipes WHERE recipeId = :recipeId)")
    suspend fun exists(recipeId: String): Boolean

    @Transaction
    @Query("SELECT * FROM users WHERE user_id = :userId")
    fun getUserWithFavoriteRecipes(userId: Int): LiveData<UserWithFavRecipes>

}
