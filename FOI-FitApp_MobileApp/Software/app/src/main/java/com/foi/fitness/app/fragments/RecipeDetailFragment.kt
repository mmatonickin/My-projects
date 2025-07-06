package com.foi.fitness.app.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import com.foi.fitness.app.R
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.repositories.RecipeRepository
import com.foi.fitness.app.viewModels.RecipeDetailViewModel
import com.foi.fitness.app.viewModels.RecipeDetailViewModelFactory
import com.squareup.picasso.Picasso

class RecipeDetailFragment : Fragment() {

    private lateinit var recipeDetailViewModel: RecipeDetailViewModel

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_recipe_detail, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val recipeDao = AppDatabase.getInstance().getRecipeDao()
        val repository = RecipeRepository(recipeDao)
        val factory = RecipeDetailViewModelFactory(recipeDao, repository)

        recipeDetailViewModel = ViewModelProvider(this, factory)[RecipeDetailViewModel::class.java]

        val recipeName = arguments?.getString("recipeName") ?: ""
        val ingredients = arguments?.getString("ingredients") ?: ""
        val procedure = arguments?.getString("procedure") ?: ""
        val calories = arguments?.getInt("calories") ?: 0
        val imageUrl = arguments?.getString("imageUrl")

        val favoriteIcon = view.findViewById<ImageView>(R.id.iv_favorite_hearth)
        val imageView = view.findViewById<ImageView>(R.id.iv_detail_image)
        val recipeId = arguments?.getString("recipeId") ?: return
        val userId = arguments?.getInt("userId") ?: return

        view.findViewById<TextView>(R.id.tv_detail_recipe_name).text = recipeName
        view.findViewById<TextView>(R.id.tv_detail_ingredients).text = ingredients
        view.findViewById<TextView>(R.id.tv_detail_procedure).text = procedure
        view.findViewById<TextView>(R.id.tv_detail_calories).text = "Calories: $calories kcal"

        if (!imageUrl.isNullOrBlank()) {
            Picasso.get()
                .load(imageUrl)
                .into(imageView)
        } else {
            imageView.visibility = View.GONE
        }

        recipeDetailViewModel.isFavorite.observe(viewLifecycleOwner) { isFav ->
            favoriteIcon.setImageResource(
                if (isFav) R.drawable.baseline_favorite_24
                else R.drawable.baseline_favorite_border_24
            )
        }

        favoriteIcon.setOnClickListener {
            recipeDetailViewModel.toggleFavorite(userId, recipeId)
        }

        recipeDetailViewModel.loadFavoriteStatus(userId, recipeId)
    }
}