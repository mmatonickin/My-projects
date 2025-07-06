package com.foi.fitness.app.utils

object UserInputValidators {
    fun isNameValid(name: String): Boolean = name.isNotBlank()

    fun isSurnameValid(surname: String): Boolean = surname.isNotBlank()

    fun isWeightValid(weight: Int?): Boolean = weight != null && weight > 0

    fun isHeightValid(height: Int?): Boolean = height != null && height > 0

    fun isAgeValid(age: Int?): Boolean = age != null && age in 1..120

    fun isEmailValid(email: String): Boolean = email.isNotBlank() && android.util.Patterns.EMAIL_ADDRESS.matcher(email).matches()

    fun isUsernameValid(username: String): Boolean = username.isNotBlank()

    fun isPasswordValid(password: String): Boolean = password.length >= 5
}