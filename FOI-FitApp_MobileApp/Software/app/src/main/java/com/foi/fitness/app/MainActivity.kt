package com.foi.fitness.app

import android.content.Intent
import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.widget.Toolbar
import androidx.core.view.GravityCompat
import androidx.core.view.WindowCompat
import androidx.drawerlayout.widget.DrawerLayout
import androidx.fragment.app.Fragment
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.fragments.*
import com.foi.fitness.app.utils.SharedPreferencesManager
import com.google.android.material.bottomnavigation.BottomNavigationView
import com.google.android.material.navigation.NavigationView
import com.google.firebase.Firebase
import com.google.firebase.firestore.firestore
import androidx.appcompat.app.ActionBarDrawerToggle
import android.util.Log

class MainActivity : AppCompatActivity() {

    private lateinit var bottomNavigation: BottomNavigationView
    private lateinit var navigationDrawer: NavigationView
    private lateinit var drawerLayout: DrawerLayout

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        AppDatabase.buildInstance(applicationContext)
        enableEdgeToEdge()
        WindowCompat.setDecorFitsSystemWindows(window, false)
        setContentView(R.layout.activity_main)

        Log.d("FIRESTORE_TEST", "App se pokrenula")

        val db = Firebase.firestore
        db.collection("test")
            .get()
            .addOnSuccessListener { result ->
                for (document in result) {
                    Log.d("FIRESTORE_TEST", "Dokument ID = ${document.id}, Podaci = ${document.data}")
                }
            }
            .addOnFailureListener { e ->
                Log.e("FIRESTORE_TEST", "Greška pri čitanju: ${e.message}", e)
            }

        initViews()
        setupToolbar()
        setupBottomNavigation()
        setupDrawerNavigation()

        if (savedInstanceState == null) {
            replaceFragment(TrainingGeneratorFragment())
        }
    }

    private fun initViews() {
        bottomNavigation = findViewById(R.id.bottom_navigation)
        navigationDrawer = findViewById(R.id.navigation_drawer)
        drawerLayout = findViewById(R.id.drawer_layout)
    }

    private fun setupToolbar() {
        val toolbar = findViewById<Toolbar>(R.id.topAppBar)
        setSupportActionBar(toolbar)

        val toggle = ActionBarDrawerToggle(
            this, drawerLayout, toolbar,
            R.string.drawer_open,
            R.string.drawer_close
        )
        drawerLayout.addDrawerListener(toggle)
        toggle.syncState()
    }

    private fun setupBottomNavigation() {
        bottomNavigation.setOnItemSelectedListener { item ->
            when (item.itemId) {
                R.id.bottom_training -> replaceFragment(TrainingGeneratorFragment())
                R.id.bottom_meal -> replaceFragment(MealFragment())
                R.id.bottom_recipe -> replaceFragment(RecipeListFragment())
                R.id.bottom_game -> replaceFragment(GameFragment())
            }
            true
        }
    }

    private fun replaceFragment(fragment: Fragment) {
        supportFragmentManager.popBackStack(
            null,
            androidx.fragment.app.FragmentManager.POP_BACK_STACK_INCLUSIVE
        )
        supportFragmentManager.beginTransaction()
            .replace(R.id.fragment_container, fragment)
            .commit()
    }

    private fun setupDrawerNavigation() {
        navigationDrawer.setNavigationItemSelectedListener { item ->
            when (item.itemId) {
                R.id.drawer_training -> {
                    replaceFragment(TrainingGeneratorFragment())
                    bottomNavigation.selectedItemId = R.id.bottom_training
                }
                R.id.drawer_meal -> {
                    replaceFragment(MealFragment())
                    bottomNavigation.selectedItemId = R.id.bottom_meal
                }
                R.id.drawer_recipe -> {
                    replaceFragment(RecipeListFragment())
                    bottomNavigation.selectedItemId = R.id.bottom_recipe
                }
                R.id.drawer_game -> {
                    replaceFragment(GameFragment())
                    bottomNavigation.selectedItemId = R.id.bottom_game
                }
                R.id.drawer_logout -> {
                    SharedPreferencesManager.getInstance(applicationContext).clearUserSession()
                    val intent = Intent(this, LoginActivity::class.java)
                    intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
                    startActivity(intent)
                    finish()
                }
            }
            drawerLayout.closeDrawer(GravityCompat.START)
            true
        }
    }

    override fun onBackPressed() {
        if (drawerLayout.isDrawerOpen(GravityCompat.START)) {
            drawerLayout.closeDrawer(GravityCompat.START)
        } else {
            super.onBackPressed()
        }
    }
}