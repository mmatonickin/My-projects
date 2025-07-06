package com.foi.fitness.app.viewModels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.foi.fitness.app.models.unsplash.UnsplashPhoto
import com.foi.fitness.app.network.UnsplashApiClient
import com.foi.fitness.app.repositories.UnsplashRepository
import kotlinx.coroutines.launch

class UnsplashViewModel : ViewModel() {

    private val repository = UnsplashRepository(UnsplashApiClient.apiService)

    private val _photos = MutableLiveData<List<UnsplashPhoto>>()
    val photos: LiveData<List<UnsplashPhoto>> = _photos

    private val _error = MutableLiveData<String?>()
    val error: LiveData<String?> = _error

    fun searchPhotos(query: String) {
        viewModelScope.launch {
            try {
                val response = repository.searchPhotos(query)
                _photos.value = response?.results ?: emptyList()
                _error.value = null
            } catch (e: Exception) {
                _error.value = e.localizedMessage ?: "Unknown error"
            }
        }
    }
}
