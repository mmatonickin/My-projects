package com.foi.fitness.app.repositories

import com.foi.fitness.app.database.DAO.UserDAO
import com.foi.fitness.app.entities.User

class UserRepository (private val userDao:UserDAO){

    suspend fun registerUser(user: User){
        userDao.insertUser(user)
    }

    suspend fun isUsernameTaken(username: String): Boolean {
        return userDao.getUserByUsername(username) !=null
    }

    suspend fun getAllUsers(): List<User> { //
        return userDao.getAllUsers()
    }
}