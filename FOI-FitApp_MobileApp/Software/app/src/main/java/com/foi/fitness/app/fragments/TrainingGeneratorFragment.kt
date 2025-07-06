package com.foi.fitness.app.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.ImageButton
import android.widget.ProgressBar
import android.widget.Spinner
import android.widget.TextView
import android.widget.Toast
import androidx.cardview.widget.CardView
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.lifecycleScope
import com.foi.fitness.app.R
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.entities.GeneratedTraining
import com.foi.fitness.app.utils.SharedPreferencesManager
import com.foi.fitness.app.viewModels.GeneratedTrainingFactory
import com.foi.fitness.app.viewModels.GeneratedTrainingViewModel
import com.google.gson.Gson
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class TrainingGeneratorFragment : Fragment() {

    private lateinit var cardTraining: CardView
    private lateinit var tvDuration: TextView
    private lateinit var tvRest: TextView
    private lateinit var tvPace: TextView
    private lateinit var tvDistance: TextView
    private lateinit var spinnerGoals: Spinner
    private lateinit var spinnerType: Spinner
    private lateinit var btnGenerateTraining: Button
    private lateinit var btnAddTraining: ImageButton
    private lateinit var btnShowUserTraining: ImageButton

    private lateinit var cooldownProgressBar: ProgressBar
    private lateinit var cooldownCountdownText: TextView
    private val COOLDOWN_HOURS = 12
    private val COOLDOWN_SECONDS = COOLDOWN_HOURS * 60 * 60

    private lateinit var viewModel: GeneratedTrainingViewModel
    private var userId: Int = -1

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_training_generator, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        cardTraining = view.findViewById(R.id.trainingCard)
        tvDuration = view.findViewById(R.id.tv_training_duration)
        tvRest = view.findViewById(R.id.tv_training_rest)
        tvPace = view.findViewById(R.id.tv_training_pace)
        tvDistance = view.findViewById(R.id.tv_training_distance)
        spinnerGoals = view.findViewById(R.id.spinnerGoals)
        spinnerType = view.findViewById(R.id.spinnerActivityType)
        btnGenerateTraining = view.findViewById(R.id.btnGenerateTraining)
        cooldownProgressBar = view.findViewById(R.id.cooldownProgressBar)
        cooldownCountdownText = view.findViewById(R.id.cooldownCountdownText)
        btnAddTraining = view.findViewById(R.id.rightButton)
        btnShowUserTraining = view.findViewById(R.id.leftButton)

        userId = SharedPreferencesManager.getInstance(requireContext()).getUserId()

        val userDAO = AppDatabase.getInstance().getUsersDao()
        val factory = GeneratedTrainingFactory(userDAO)

        val prefs = SharedPreferencesManager.getInstance(requireContext())
        val lastTime = prefs.getLong(getCooldownPrefKey(userId), 0L)
        val currentTime = System.currentTimeMillis()
        val secondsSinceLast = (currentTime - lastTime) / 1000
        val remaining = COOLDOWN_SECONDS - secondsSinceLast

        val trainingJsonFromSharedPrefs = prefs.getString(getTrainingPrefKey(userId), "")

        viewModel = ViewModelProvider(this, factory)[GeneratedTrainingViewModel::class.java]

        /*
        SharedPreferencesManager.getInstance(requireContext())
        prefs.removeKey(getCooldownPrefKey(userId))
         */

        if(trainingJsonFromSharedPrefs.isNotEmpty() && remaining > 0) {
            val lastTraining = Gson().fromJson(trainingJsonFromSharedPrefs, GeneratedTraining::class.java)

            tvDuration.text = "${lastTraining.duration} min"
            tvRest.text = "${lastTraining.rest} min"
            tvPace.text = "${lastTraining.pace} km/h"
            tvDistance.text = "${lastTraining.distance} km"

            cardTraining.visibility = View.VISIBLE
        }

        viewModel.trainingGoals.observe(viewLifecycleOwner) { goals ->
            if (goals.isNotEmpty()) {
                val adapter = ArrayAdapter(requireContext(), android.R.layout.simple_spinner_item, goals)
                adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
                spinnerGoals.adapter = adapter
            } else {
                cardTraining.visibility = View.GONE
            }
        }
        btnAddTraining.setOnClickListener {
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragment_container, TrainingFragment())
                .addToBackStack(null)
                .commit()
        }

        btnShowUserTraining.setOnClickListener {
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragment_container, TrainingListFragment())
                .addToBackStack(null)
                .commit()
        }

        btnGenerateTraining.setOnClickListener {
            val selectedSpinnerGoal = spinnerGoals.selectedItem.toString()
            val selectedSpinnerType = spinnerType.selectedItem.toString()

            val defaultGoal = getString(R.string.select_training_goal_default_value)
            val defaultType = getString(R.string.select_training_type_default_value)

            if(selectedSpinnerType == defaultType || selectedSpinnerGoal == defaultGoal){
                Toast.makeText(requireContext(), "Please choose training type and goal", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            viewModel.loadAdequateTrainingForUser(userId, selectedSpinnerGoal, selectedSpinnerType)

        }
        observeViewModel()
        checkCooldown()
    }

    private fun observeViewModel() {
        viewModel.trainingResult.observe(viewLifecycleOwner) {training ->
            if(training !=null) {
                tvDuration.text = "${training.duration} min"
                tvRest.text = "${training.rest} min"
                tvPace.text = "${training.pace} km/h"
                tvDistance.text = "${training.distance} km"

                cardTraining.visibility = View.VISIBLE

                val prefs = SharedPreferencesManager.getInstance(requireContext())
                prefs.saveLong(getCooldownPrefKey(userId), System.currentTimeMillis())

                val trainingJson = Gson().toJson(training)
                prefs.saveString(getTrainingPrefKey(userId), trainingJson)

                checkCooldown()
            } else {
                Toast.makeText(requireContext(), "No training found according to your preferences.", Toast.LENGTH_SHORT).show()
                cardTraining.visibility = View.GONE
            }
        }
    }

    override fun onResume() {
        super.onResume()
        checkCooldown()
    }

    private fun getCooldownPrefKey(userId: Int): String {
        return "last_training_generation_user_$userId"
    }

    private fun getTrainingPrefKey(userId: Int): String{
        return "last_generated_training_user_${userId}"
    }

    private fun checkCooldown() {
        val prefs = SharedPreferencesManager.getInstance(requireContext())
        val lastTime = prefs.getLong(getCooldownPrefKey(userId), 0L)
        val currentTime = System.currentTimeMillis()
        val secondsSinceLast = (currentTime - lastTime) / 1000
        val remaining = COOLDOWN_SECONDS - secondsSinceLast

        if(remaining <= 0) {
            btnGenerateTraining.isEnabled=true
            cooldownProgressBar.visibility = View.GONE
            cooldownCountdownText.visibility = View.GONE
            cardTraining.visibility = View.GONE

            prefs.removeKey(getTrainingPrefKey(userId))
            prefs.removeKey(getCooldownPrefKey(userId))

            return
        }
            btnGenerateTraining.isEnabled = false
            cooldownProgressBar.visibility = View.VISIBLE
            cooldownCountdownText.visibility = View.VISIBLE
            cooldownProgressBar.max = COOLDOWN_SECONDS
            cooldownProgressBar.progress = secondsSinceLast.toInt()

        viewLifecycleOwner.lifecycleScope.launch {
            var timeLeft = remaining
            while (timeLeft > 0){
                val hours = timeLeft / 3600
                val minutes = (timeLeft % 3600) / 60
                val seconds = timeLeft % 60

                cooldownCountdownText.text = String.format(
                    "Training generator available in: %02d:%02d:%02d",
                    hours, minutes, seconds
                )

                delay(1000L)
                timeLeft--
                if (cooldownProgressBar.progress < COOLDOWN_SECONDS) {
                    cooldownProgressBar.progress++
                    }
                }
                cooldownProgressBar.visibility = View.GONE
                cooldownCountdownText.visibility = View.GONE
                btnGenerateTraining.isEnabled = true
                cardTraining.visibility = View.GONE
            }
        }
    }