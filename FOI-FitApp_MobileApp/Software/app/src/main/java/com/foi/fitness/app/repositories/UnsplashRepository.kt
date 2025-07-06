package com.foi.fitness.app.repositories

import android.util.Log
import com.foi.fitness.app.models.unsplash.UnsplashResponse
import com.foi.fitness.app.network.UnsplashApiService
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext

class UnsplashRepository(private val apiService: UnsplashApiService) {

    suspend fun searchPhotos(query: String): UnsplashResponse? {
        return withContext(Dispatchers.IO) {
            try {
                apiService.searchPhotos(query = query)
            }catch (e: Exception) {
                    Log.e("UnsplashRepository", "Error loading images", e)
                    null
                }
            }
    }
}