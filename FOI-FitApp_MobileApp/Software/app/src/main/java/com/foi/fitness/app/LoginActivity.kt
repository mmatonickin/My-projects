package com.foi.fitness.app

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.utils.SharedPreferencesManager
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import kotlin.math.log

class LoginActivity : AppCompatActivity() {

    private lateinit var etUsername: EditText
    private lateinit var etPassword: EditText
    private lateinit var btnLogin: Button
    private lateinit var tvGoToSignup: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        // Show success message if redirected from registration
        if (intent.getBooleanExtra("registration_success", false)) {
            Toast.makeText(this, "Successful registration! Please log in.", Toast.LENGTH_LONG).show()
        }

        AppDatabase.buildInstance(applicationContext)

        etUsername = findViewById(R.id.etUsername)
        etPassword = findViewById(R.id.etPassword)
        btnLogin = findViewById(R.id.btnLogin)
        tvGoToSignup = findViewById(R.id.tvGoToSignup)

        btnLogin.setOnClickListener {
            val username = etUsername.text.toString().trim()
            val password = etPassword.text.toString().trim()

            if (username.isEmpty() || password.isEmpty()) {
                Toast.makeText(this, "Please fill in all fields", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }

            lifecycleScope.launch {
                val user = withContext(Dispatchers.IO) {
                    val db = AppDatabase.getInstance()
                    val dao = db.getUsersDao()
                    val foundUser = dao.getUserByUsername(username)
                    if (foundUser != null && foundUser.password == password) {
                        foundUser
                    } else {
                        null
                    }
                }

                if (user != null) {
                    SharedPreferencesManager.getInstance(applicationContext).setUserId(user.userId)
                    Log.i("USER_SESSION", "Spremljeni userId: ${user.userId}")
                    navigateToHome()
                } else {
                    Toast.makeText(
                        this@LoginActivity,
                        "Invalid username or password",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            }
        }

        tvGoToSignup.setOnClickListener {
            val intent = Intent(this, SignUpActivity::class.java)
            startActivity(intent)
        }
    }

    private fun navigateToHome() {
        val intent = Intent(this, MainActivity::class.java)
        startActivity(intent)
        finish()
    }
}