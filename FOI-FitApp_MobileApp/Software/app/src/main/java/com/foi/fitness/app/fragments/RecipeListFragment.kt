package com.foi.fitness.app.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.*
import androidx.appcompat.app.AlertDialog
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.airbnb.lottie.LottieAnimationView
import com.foi.fitness.app.R
import com.foi.fitness.app.adapters.RecipeAdapter
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.utils.SharedPreferencesManager
import com.foi.fitness.app.viewModels.RecipeViewModel
import com.foi.fitness.app.viewModels.RecipeViewModelFactory

class RecipeListFragment : Fragment() {

    private lateinit var progressBar: LottieAnimationView
    private lateinit var viewModel: RecipeViewModel
    private lateinit var recyclerView: RecyclerView
    private lateinit var btnAddRecipe: Button
    private lateinit var btnOpenFilter: ImageButton
    private lateinit var btnSortRecipes: ImageButton
    private lateinit var tvNoRecipes: TextView
    private lateinit var adapter: RecipeAdapter
    private lateinit var btnShowFavoriteRecipes: ImageButton
    private var userId: Int = -1

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View = inflater.inflate(R.layout.fragment_recipe_list, container, false)

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        progressBar = view.findViewById(R.id.progress_bar)
        recyclerView = view.findViewById(R.id.rv_recipes)
        btnAddRecipe = view.findViewById(R.id.btn_add_recipe)
        btnOpenFilter = view.findViewById(R.id.btn_open_filter)
        btnSortRecipes = view.findViewById(R.id.btn_sort_recipes)
        tvNoRecipes = view.findViewById(R.id.tv_no_recipes)
        btnShowFavoriteRecipes = view.findViewById(R.id.btn_favorites)

        userId = SharedPreferencesManager.getInstance(requireContext()).getUserId()

        val recipeDAO = AppDatabase.getInstance().getRecipeDao()
        val factory = RecipeViewModelFactory(recipeDAO)
        viewModel = ViewModelProvider(this, factory)[RecipeViewModel::class.java]

        viewModel.loadRecipes()

        adapter = RecipeAdapter { recipe ->
            val bundle = Bundle().apply {
                putString("recipeName", recipe.recipeName)
                putString("ingredients", recipe.ingredients)
                putString("procedure", recipe.procedure)
                putInt("calories", recipe.calories)
                putString("recipeId", recipe.recipeId)
                putInt("userId", userId)
                putString("imageUrl", recipe.imageUri)

            }
            parentFragmentManager.beginTransaction()
                .replace(
                    R.id.fragment_container,
                    RecipeDetailFragment().apply { arguments = bundle })
                .addToBackStack(null)
                .commit()
        }
        recyclerView.layoutManager = LinearLayoutManager(requireContext())
        recyclerView.adapter = adapter

        btnShowFavoriteRecipes.setOnClickListener {
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragment_container, FavoriteRecipesFragment())
                .addToBackStack(null)
                .commit()
        }

        btnAddRecipe.setOnClickListener {
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragment_container, RecipeFragment())
                .addToBackStack(null)
                .commit()
        }

        setupFilterButton()
        setupSortButton()

        observeViewModel()
    }

    private fun observeViewModel() {
        viewModel.recipes.observe(viewLifecycleOwner) { recipeList ->
            adapter.setRecipes(recipeList)
            tvNoRecipes.visibility = if (recipeList.isEmpty()) View.VISIBLE else View.GONE
        }

        viewModel.isLoading.observe(viewLifecycleOwner) { isLoading ->
            if (isLoading && viewModel.recipes.value.isNullOrEmpty()) {
                progressBar.visibility = View.VISIBLE
                progressBar.playAnimation()
            } else {
                progressBar.cancelAnimation()
                progressBar.visibility = View.GONE
            }
        }
    }

    private fun setupFilterButton() {
        btnOpenFilter.setOnClickListener {
            val ingredients =
                resources.getStringArray(R.array.ingredient_filter_options).toMutableList()
            ingredients.add("Enter custom ingredient...")
            var selected = 0

            AlertDialog.Builder(requireContext())
                .setTitle("Filter by ingredient")
                .setSingleChoiceItems(ingredients.toTypedArray(), selected) { _, which ->
                    selected = which
                }
                .setPositiveButton("Apply") { _, _ ->
                    when (val selectedIngredient = ingredients[selected]) {
                        "All" -> viewModel.setIngredientFilter(null)
                        "Enter custom ingredient..." -> showCustomIngredientDialog()
                        else -> applyIngredientFilter(selectedIngredient)
                    }
                }
                .setNegativeButton("Cancel", null)
                .show()
        }
    }

    private fun showCustomIngredientDialog() {
        val input = EditText(requireContext())
        input.hint = "Type an ingredient"

        AlertDialog.Builder(requireContext())
            .setTitle("Enter custom ingredient")
            .setView(input)
            .setPositiveButton("Filter") { _, _ ->
                val customIngredient = input.text.toString().trim()
                if (customIngredient.isNotEmpty()) {
                    applyIngredientFilter(customIngredient)
                } else {
                    Toast.makeText(
                        requireContext(),
                        "Ingredient cannot be empty.",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            }
            .setNegativeButton("Cancel", null)
            .show()
    }

    private fun applyIngredientFilter(ingredient: String) {
        viewModel.setIngredientFilter(ingredient)
    }

    private fun setupSortButton() {
        btnSortRecipes.setOnClickListener {
            val ranges = arrayOf("0–499 kcal", "500–999 kcal", "1000+ kcal")
            var selected = 0

            AlertDialog.Builder(requireContext())
                .setTitle("Sort by calories")
                .setSingleChoiceItems(ranges, selected) { _, which -> selected = which }
                .setPositiveButton("Apply") { _, _ ->
                    val (min, max) = when (selected) {
                        0 -> 0 to 499
                        1 -> 500 to 999
                        else -> 1000 to Int.MAX_VALUE
                    }
                    applyCaloriesSort(min, max)
                }
                .setNegativeButton("Cancel", null)
                .show()
        }
    }

    private fun applyCaloriesSort(min: Int, max: Int) {
        viewModel.setCaloriesRange(min, max)
    }

    override fun onDestroyView() {
        super.onDestroyView()
        progressBar.cancelAnimation()
    }

    override fun onResume() {
        super.onResume()
        viewModel.loadRecipes()
    }
}
