package com.foi.fitness.app.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.foi.fitness.app.R
import com.foi.fitness.app.entities.Training
import com.foi.fitness.app.models.enums.TrainingType
import java.text.SimpleDateFormat
import java.util.Locale

class TrainingAdapter (
    private val onItemClick: (Training) -> Unit
): RecyclerView.Adapter<TrainingAdapter.TrainingViewHolder>() {

    private var trainingList: List<Training> = emptyList()

    fun setTrainings(newList: List<Training>) {
        trainingList = newList
        notifyDataSetChanged()
    }

    class TrainingViewHolder (view: View): RecyclerView.ViewHolder(view) {
        val type: TextView = view.findViewById(R.id.tv_userTraining_type)
        val date: TextView = view.findViewById(R.id.tv_userTraining_date)
        val status: TextView = view.findViewById(R.id.tv_training_status)
        val icon: ImageView = view.findViewById(R.id.iv_training_icon)

    }


    override fun onCreateViewHolder (parent: ViewGroup, viewType: Int): TrainingViewHolder{
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.training_item, parent, false)
        return TrainingViewHolder(view)
    }

    override fun onBindViewHolder(holder: TrainingAdapter.TrainingViewHolder, position: Int) {
        val training = trainingList[position]
        val formatter = SimpleDateFormat("dd.MM.yyyy", Locale.getDefault())
        val formattedDate = formatter.format(training.trainingDate)

        val currentTime = System.currentTimeMillis()
        val trainingTime = training.trainingDate.time

        val context = holder.itemView.context
        val statusTextDone = context.getString(R.string.status_done)
        val statusTextUpcoming = context.getString(R.string.status_upcoming)

        if(trainingTime> currentTime) {
            holder.status.text = statusTextUpcoming
            holder.status.setTextColor(context.getColor(R.color.upcoming_training_status_color))
        } else {
            holder.status.text = statusTextDone
            holder.status.setTextColor(context.getColor(R.color.done_training_status_color))
        }

        holder.type.text = "Training type: ${training.trainingType}"
        holder.date.text = "Date: ${formattedDate}"

        when(training.trainingType) {
            TrainingType.Run -> holder.icon.setImageResource(R.drawable.baseline_directions_run_24)
            TrainingType.Walk -> holder.icon.setImageResource(R.drawable.baseline_directions_walk_24)
        }

        holder.itemView.setOnClickListener {
            onItemClick(training)
        }
    }

    override fun getItemCount(): Int = trainingList.size
}