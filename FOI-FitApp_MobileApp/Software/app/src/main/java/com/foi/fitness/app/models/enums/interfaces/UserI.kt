package com.foi.fitness.app.models.enums.interfaces

import com.foi.fitness.app.models.enums.Genre

interface UserI {

    val name: String
    val surname: String
    val weight: Int
    val height: Int
    val genre: Genre
    val email: String
    val username: String
    val password: String
    val age: Int
    val highScore: Int

}