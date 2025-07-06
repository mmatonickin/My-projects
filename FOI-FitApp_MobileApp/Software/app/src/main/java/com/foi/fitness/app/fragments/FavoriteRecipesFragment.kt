package com.foi.fitness.app.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.foi.fitness.app.R
import com.foi.fitness.app.adapters.RecipeAdapter
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.repositories.RecipeRepository
import com.foi.fitness.app.utils.SharedPreferencesManager
import com.foi.fitness.app.viewModels.FavoriteRecipesViewModel
import com.foi.fitness.app.viewModels.FavoriteRecipesViewModelFactory
import com.foi.fitness.app.viewModels.UserTrainingViewModel

class FavoriteRecipesFragment : Fragment() {

    private lateinit var favoriteRecipesViewModel: FavoriteRecipesViewModel
    private lateinit var adapter: RecipeAdapter
    private lateinit var recyclerView: RecyclerView
    private lateinit var tvNoAddedFavorites: TextView

    private var userId: Int = -1

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_favorite_recipes, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        userId = SharedPreferencesManager.getInstance(requireContext()).getUserId()

        val recipeDao = AppDatabase.getInstance().getRecipeDao()
        val repository = RecipeRepository(recipeDao)
        val factory = FavoriteRecipesViewModelFactory(repository)
        favoriteRecipesViewModel = ViewModelProvider(this, factory)[FavoriteRecipesViewModel::class.java]

        recyclerView = view.findViewById(R.id.rv_favorite_recipes)
        tvNoAddedFavorites = view.findViewById(R.id.tv_no_favorites)

        adapter = RecipeAdapter { recipe ->
            val bundle = Bundle().apply {
                putString("recipeName", recipe.recipeName)
                putString("ingredients", recipe.ingredients)
                putString("procedure", recipe.procedure)
                putInt("calories", recipe.calories)
                putString("recipeId", recipe.recipeId)
                putInt("userId", userId)

            }
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragment_container, RecipeDetailFragment().apply {
                    arguments = bundle
                })
                .addToBackStack(null)
                .commit()
        }

        recyclerView.layoutManager = LinearLayoutManager(requireContext())
        recyclerView.adapter = adapter

        observeFavoriteRecipes()
    }

    private fun observeFavoriteRecipes() {
        favoriteRecipesViewModel.loadFavoriteRecipes(userId).observe(viewLifecycleOwner) { favorites ->
            adapter.setRecipes(favorites)
            tvNoAddedFavorites.visibility = if (favorites.isEmpty()) View.VISIBLE else View.GONE
        }
    }
}