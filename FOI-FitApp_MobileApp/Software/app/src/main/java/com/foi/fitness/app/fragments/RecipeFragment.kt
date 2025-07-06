package com.foi.fitness.app.fragments

import android.os.Bundle
import android.text.Editable
import android.text.TextWatcher
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.*
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import com.foi.fitness.app.R
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.entities.Recipe
import com.foi.fitness.app.utils.SharedPreferencesManager
import com.foi.fitness.app.viewModels.RecipeViewModel
import com.foi.fitness.app.viewModels.RecipeViewModelFactory
import com.squareup.picasso.Picasso

class RecipeFragment : Fragment() {

    private lateinit var etDishName: EditText
    private lateinit var etIngredients: EditText
    private lateinit var etProcedure: EditText
    private lateinit var etCalories: EditText
    private lateinit var etImageUrl: EditText
    private lateinit var btnAdd: Button
    private lateinit var ivSelectedImage: ImageView
    private lateinit var overlayLayout: FrameLayout
    private lateinit var tvTapToSearch: TextView

    private lateinit var viewModel: RecipeViewModel

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View = inflater.inflate(R.layout.fragment_recipe, container, false)

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        initViews(view)
        initViewModel()
        setupListeners()
        observeViewModel()
    }

    private fun initViews(view: View) {
        etDishName = view.findViewById(R.id.et_dish_name)
        etIngredients = view.findViewById(R.id.et_ingredients)
        etProcedure = view.findViewById(R.id.et_procedure)
        etCalories = view.findViewById(R.id.et_calories)
        etImageUrl = view.findViewById(R.id.et_image_url)
        btnAdd = view.findViewById(R.id.btn_add_recipe)
        ivSelectedImage = view.findViewById(R.id.iv_selected_image)
        overlayLayout = view.findViewById(R.id.add_image_overlay)
        tvTapToSearch = view.findViewById(R.id.tv_tap_to_search)
    }

    private fun initViewModel() {
        val recipeDAO = AppDatabase.getInstance().getRecipeDao()
        val factory = RecipeViewModelFactory(recipeDAO)
        viewModel = ViewModelProvider(this, factory)[RecipeViewModel::class.java]
    }

    private fun setupListeners() {
        etImageUrl.addTextChangedListener(object : TextWatcher {
            override fun afterTextChanged(s: Editable?) {
                val url = s?.toString()?.trim()
                if (!url.isNullOrEmpty()) {
                    Picasso.get()
                        .load(url)
                        .into(ivSelectedImage, object : com.squareup.picasso.Callback {
                            override fun onSuccess() {
                                ivSelectedImage.visibility = View.VISIBLE
                                overlayLayout.visibility = View.VISIBLE
                            }

                            override fun onError(e: Exception?) {
                                Toast.makeText(
                                    requireContext(),
                                    "Invalid image URL",
                                    Toast.LENGTH_SHORT
                                ).show()
                            }
                        })
                }
            }

            override fun beforeTextChanged(s: CharSequence?, start: Int, count: Int, after: Int) {}
            override fun onTextChanged(s: CharSequence?, start: Int, before: Int, count: Int) {}
        })

        overlayLayout.setOnClickListener {
            val dialog = ImageSearchDialogFragment()
            dialog.setOnImageSelectedListener { imageUrl ->
                etImageUrl.setText(imageUrl)
                Picasso.get().load(imageUrl).into(ivSelectedImage)
                ivSelectedImage.visibility = View.VISIBLE
                tvTapToSearch.visibility = View.GONE
                overlayLayout.visibility = View.VISIBLE
            }
            dialog.show(parentFragmentManager, "ImageSearchDialog")
        }

        btnAdd.setOnClickListener {
            val recipe = collectRecipeInput()
            if (recipe != null) {
                viewModel.addRecipe(recipe)
            }
        }
    }

    private fun collectRecipeInput(): Recipe? {
        val name = etDishName.text.toString().trim()
        val ingredients = etIngredients.text.toString().trim()
        val procedure = etProcedure.text.toString().trim()
        val caloriesStr = etCalories.text.toString().trim()
        val calories = caloriesStr.toIntOrNull() ?: -1
        val userId = SharedPreferencesManager.getInstance(requireContext()).getUserId()
        val imageUrl = etImageUrl.text.toString().trim().takeIf { it.isNotEmpty() }

        if (name.isEmpty() || ingredients.isEmpty() || procedure.isEmpty() || calories < 0) {
            Toast.makeText(requireContext(), "Please fill in all fields correctly", Toast.LENGTH_SHORT).show()
            return null
        }

        return Recipe(
            recipeId = "",
            recipeName = name,
            ingredients = ingredients,
            procedure = procedure,
            calories = calories,
            userId = userId,
            imageUri = imageUrl
        )
    }

    private fun observeViewModel() {
        viewModel.message.observe(viewLifecycleOwner) { msg ->
            Toast.makeText(requireContext(), msg, Toast.LENGTH_SHORT).show()
        }

        viewModel.addSuccess.observe(viewLifecycleOwner) { success ->
            if (success) {
                clearFields()
                parentFragmentManager.popBackStack()
            }
        }
    }

    private fun clearFields() {
        etDishName.text.clear()
        etIngredients.text.clear()
        etProcedure.text.clear()
        etCalories.text.clear()
        etImageUrl.text.clear()
        ivSelectedImage.setImageDrawable(null)
        ivSelectedImage.visibility = View.GONE
        overlayLayout.visibility = View.VISIBLE
    }
}
