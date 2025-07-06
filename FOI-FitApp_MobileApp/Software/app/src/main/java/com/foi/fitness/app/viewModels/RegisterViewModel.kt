package com.foi.fitness.app.viewModels

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.foi.fitness.app.entities.User
import com.foi.fitness.app.repositories.UserRepository
import kotlinx.coroutines.launch


class RegisterViewModel(private val userRepository: UserRepository): ViewModel() {
    private val _registrationResult = MutableLiveData<Boolean>()
    val registrationResult: LiveData<Boolean> = _registrationResult

    fun register(user: User) {
        viewModelScope.launch {
            val exists = userRepository.isUsernameTaken(user.username)

            if (exists) {
                _registrationResult.postValue(false)
            } else {
                userRepository.registerUser(user)
                val users = userRepository.getAllUsers()
                Log.d("DB_DEBUG", "Korisnici nakon inserta: ${users.joinToString { it.username }}")
                _registrationResult.postValue(true)


            }
        }
    }

}