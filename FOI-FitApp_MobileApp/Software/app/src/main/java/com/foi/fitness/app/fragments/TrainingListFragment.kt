package com.foi.fitness.app.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.foi.fitness.app.R
import com.foi.fitness.app.adapters.TrainingAdapter
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.database.DAO.TrainingDAO
import com.foi.fitness.app.repositories.TrainingRepository
import com.foi.fitness.app.utils.SharedPreferencesManager
import com.foi.fitness.app.viewModels.UserTrainingViewModel
import com.foi.fitness.app.viewModels.UserTrainingViewModelFactory

class TrainingListFragment() : Fragment() {

    private lateinit var userTrainingViewModel: UserTrainingViewModel
    private lateinit var trainingAdapter: TrainingAdapter
    private lateinit var recyclerView: RecyclerView
    private lateinit var tvNoTrainingsFound: TextView

    private var userId: Int = -1

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_training_list, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        recyclerView = view.findViewById(R.id.rv_user_trainings)
        tvNoTrainingsFound = view.findViewById(R.id.tv_no_trainings)

        val trainingDao = AppDatabase.getInstance().getTrainingDao()
        val repository = TrainingRepository(trainingDao)
        val factory = UserTrainingViewModelFactory(repository)
        userTrainingViewModel = ViewModelProvider(this, factory)[UserTrainingViewModel::class.java]

        userId = SharedPreferencesManager.getInstance(requireContext()).getUserId()

        trainingAdapter = TrainingAdapter {}
        recyclerView.layoutManager = LinearLayoutManager(requireContext())
        recyclerView.adapter = trainingAdapter

        observeModel()
        userTrainingViewModel.loadUserTrainings(userId)
    }

    private fun observeModel() {
        userTrainingViewModel.trainings.observe(viewLifecycleOwner) { trainings ->
            trainingAdapter.setTrainings(trainings)
            tvNoTrainingsFound.visibility = if(trainings.isEmpty()) View.VISIBLE else View.GONE
        }
    }

    override fun onResume() {
        super.onResume()
        userTrainingViewModel.loadUserTrainings(userId)
    }
}