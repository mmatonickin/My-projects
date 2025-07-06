package com.foi.fitness.app.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.lifecycle.lifecycleScope
import com.foi.fitness.app.R
import com.foi.fitness.app.repositories.RecipeRepository
import kotlinx.coroutines.launch

class MealFragment : Fragment() {

    private lateinit var caloriesInput: EditText
    private lateinit var suggestButton: Button
    private lateinit var ingredientsText: TextView
    private lateinit var procedureText: TextView
    private lateinit var caloriesText: TextView

    private lateinit var recipeRepository: RecipeRepository

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_meal, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        caloriesInput=view.findViewById(R.id.et_calorie_input)
        suggestButton=view.findViewById(R.id.btn_generate_meal)
        ingredientsText=view.findViewById(R.id.tv_ingredients)
        procedureText=view.findViewById(R.id.tv_procedure)
        caloriesText=view.findViewById(R.id.tv_estimated_calories)

        recipeRepository= RecipeRepository()

        suggestButton.setOnClickListener {
            val calories = caloriesInput.text.toString().toIntOrNull()
            if(calories == null){
                Toast.makeText(requireContext(), "Enter a valid number of calories", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }

            viewLifecycleOwner.lifecycleScope.launch {
                val recipe = recipeRepository.getRecipeByCalories(calories)

                if(recipe !=null){
                    procedureText.text=recipe.procedure
                    ingredientsText.text=recipe.ingredients
                    caloriesText.text = recipe.calories.toString()

                }else {
                    Toast.makeText(requireContext(), "There are no recipes in that calorie range", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

}