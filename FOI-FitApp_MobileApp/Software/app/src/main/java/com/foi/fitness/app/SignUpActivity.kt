package com.foi.fitness.app

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.foi.fitness.app.fragments.RegistrationFragment

class SignUpActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_signup)

        supportFragmentManager.beginTransaction()
            .replace(R.id.signup_container, RegistrationFragment())
            .commit()
    }
}
