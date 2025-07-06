package com.foi.fitness.app.utils

import android.content.Context
import android.content.SharedPreferences

class SharedPreferencesManager private constructor(context: Context) {

    private val sharedPreferences: SharedPreferences = context.getSharedPreferences(
        "FOI_FITNESS_PREFS", Context.MODE_PRIVATE
    )

    fun getUserId(): Int {
        return sharedPreferences.getInt(KEY_USER_ID, -1)
    }

    fun setUserId(userId: Int) {
        sharedPreferences.edit().putInt(KEY_USER_ID, userId).apply()
    }

    fun saveLong(key: String, value: Long) {
        sharedPreferences.edit().putLong(key, value).apply()
    }

    fun getLong(key: String, defaultValue: Long = 0L): Long {
        return sharedPreferences.getLong(key, defaultValue)
    }
    fun saveString(key: String, value: String) {
        sharedPreferences.edit().putString(key, value).apply()
    }

    fun getString(key: String, defaultValue: String = ""): String {
        return sharedPreferences.getString(key, defaultValue) ?: defaultValue
    }
    fun removeKey(key: String) {
        sharedPreferences.edit().remove(key).apply()
    }
    fun clearUserSession(){
        sharedPreferences.edit().remove(KEY_USER_ID).apply()
    }

    companion object {
        private const val KEY_USER_ID = "user_id"
        private var instance: SharedPreferencesManager? = null

        fun getInstance(context: Context): SharedPreferencesManager {
            if (instance == null) {
                instance = SharedPreferencesManager(context.applicationContext)
            }
            return instance!!
        }
    }
}
