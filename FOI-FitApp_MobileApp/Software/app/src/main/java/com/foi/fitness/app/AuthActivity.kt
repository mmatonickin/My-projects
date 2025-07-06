package com.foi.fitness.app

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.fragments.RegistrationFragment


class AuthActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        AppDatabase.buildInstance(applicationContext)
        setContentView(R.layout.activity_auth)

        supportFragmentManager.beginTransaction()
            .replace(R.id.fragment_container,RegistrationFragment())
            .commit()

    }
}