package com.foi.fitness.app.adapters

import com.foi.fitness.app.models.ScoreEntry
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.foi.fitness.app.R

class ScoreAdapter(private val scores: List<ScoreEntry>) :
    RecyclerView.Adapter<ScoreAdapter.ScoreViewHolder>() {

    class ScoreViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val txtUsername: TextView = itemView.findViewById(R.id.txtUsername)
        val txtScore: TextView = itemView.findViewById(R.id.txtScore)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ScoreViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_score_entry, parent, false)
        return ScoreViewHolder(view)
    }

    override fun onBindViewHolder(holder: ScoreViewHolder, position: Int) {
        val entry = scores[position]
        holder.txtUsername.text = entry.username
        holder.txtScore.text = entry.score.toString()
    }

    override fun getItemCount() = scores.size
}
