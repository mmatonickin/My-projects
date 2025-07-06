package com.foi.fitness.app.models.unsplash

data class UnsplashResponse(
    val total: Int,
    val total_pages: Int,
    val results: List<UnsplashPhoto>
)

