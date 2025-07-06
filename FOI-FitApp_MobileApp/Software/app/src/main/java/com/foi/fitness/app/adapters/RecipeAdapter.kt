package com.foi.fitness.app.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.foi.fitness.app.R
import com.foi.fitness.app.entities.Recipe

class RecipeAdapter (
    private val onItemClick: (Recipe) -> Unit
) : RecyclerView.Adapter<RecipeAdapter.RecipeViewHolder>() {

    private var recipeList: List<Recipe> = emptyList()

    fun setRecipes(newList: List<Recipe>) {
        recipeList = newList
        notifyDataSetChanged()
    }

    class RecipeViewHolder (view: View): RecyclerView.ViewHolder(view){
        val name: TextView = view.findViewById(R.id.tv_recipe_name)
        val ingredients: TextView = view.findViewById(R.id.tv_recipe_ingredients)
        val procedure: TextView = view.findViewById(R.id.tv_recipe_procedure)
        val calories: TextView = view.findViewById(R.id.tv_recipe_calories)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): RecipeViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_recipe, parent, false)
        return RecipeViewHolder(view)
    }
    override fun onBindViewHolder(holder: RecipeViewHolder, position: Int) {
        val recipe = recipeList[position]
        holder.name.text = recipe.recipeName
        holder.ingredients.text="Ingredients: ${recipe.ingredients}"
        holder.procedure.text = "Procedure: ${recipe.procedure}"
        holder.calories.text = "Calories: ${recipe.calories} kcal"

        holder.itemView.setOnClickListener {
            onItemClick(recipe)
        }
    }

    override fun getItemCount(): Int = recipeList.size
}


