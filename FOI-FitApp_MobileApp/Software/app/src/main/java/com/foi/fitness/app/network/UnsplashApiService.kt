package com.foi.fitness.app.network

import com.foi.fitness.app.models.unsplash.UnsplashResponse
import retrofit2.http.GET
import retrofit2.http.Query

interface UnsplashApiService {
    @GET("search/photos")
    suspend fun searchPhotos(
        @Query("query") query: String,
        @Query("per_page") perPage: Int = 30
    ): UnsplashResponse
}


