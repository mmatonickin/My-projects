package com.foi.fitness.app.fragments

import android.app.DatePickerDialog
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import com.foi.fitness.app.R
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.entities.Training
import com.foi.fitness.app.models.enums.TrainingType
import com.foi.fitness.app.repositories.TrainingRepository
import com.foi.fitness.app.utils.SharedPreferencesManager
import kotlinx.coroutines.launch
import java.text.SimpleDateFormat
import java.util.*

class TrainingFragment : Fragment() {

    private val calendar: Calendar = Calendar.getInstance()

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        return inflater.inflate(R.layout.fragment_training, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        setupSpinner(view)
        setupDatePicker(view)
        setupSaveButton(view)
    }

    private fun setupSpinner(view: View) {
        val spinner = view.findViewById<Spinner>(R.id.spinner_training_type)

        ArrayAdapter.createFromResource(
            requireContext(),
            R.array.training_types,
            android.R.layout.simple_spinner_item
        ).also { adapter ->
            adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
            spinner.adapter = adapter
        }

        spinner.setSelection(0)
    }

    private fun setupDatePicker(view: View) {
        val etSelectDate = view.findViewById<EditText>(R.id.et_select_date)

        etSelectDate.setOnClickListener {
            showDatePickerDialog(etSelectDate)
        }
    }

    private fun showDatePickerDialog(editText: EditText) {
        val dateSetListener = DatePickerDialog.OnDateSetListener { _, year, month, dayOfMonth ->
            calendar.set(Calendar.YEAR, year)
            calendar.set(Calendar.MONTH, month)
            calendar.set(Calendar.DAY_OF_MONTH, dayOfMonth)

            val format = SimpleDateFormat("dd.MM.yyyy", Locale.getDefault())
            editText.setText(format.format(calendar.time))
        }

        DatePickerDialog(
            requireContext(),
            dateSetListener,
            calendar.get(Calendar.YEAR),
            calendar.get(Calendar.MONTH),
            calendar.get(Calendar.DAY_OF_MONTH)
        ).show()
    }

    private fun setupSaveButton(view: View) {
        val btnSave = view.findViewById<Button>(R.id.btn_save_training)
        val spinner = view.findViewById<Spinner>(R.id.spinner_training_type)
        val etDate = view.findViewById<EditText>(R.id.et_select_date)

        btnSave.setOnClickListener {
            val selectedPosition = spinner.selectedItemPosition
            val dateText = etDate.text.toString()

            val userId = SharedPreferencesManager.getInstance(requireContext()).getUserId()


            if (userId == -1) {
                Toast.makeText(requireContext(), "User not logged in!", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }

            when {
                selectedPosition == 0 -> {
                    Toast.makeText(requireContext(), getString(R.string.error_select_training_type), Toast.LENGTH_SHORT).show()
                }
                dateText.isBlank() -> {
                    Toast.makeText(requireContext(), getString(R.string.error_select_date), Toast.LENGTH_SHORT).show()
                }
                else -> {
                    val training = Training(
                        trainingId = 0,
                        trainingType = TrainingType.valueOf(spinner.selectedItem.toString()),
                        trainingDate = SimpleDateFormat("dd.MM.yyyy", Locale.getDefault()).parse(dateText)!!,
                        completed = false,
                        userId = userId
                    )

                    val db = AppDatabase.getInstance()
                    val repo = TrainingRepository(db.getTrainingDao())

                    lifecycleScope.launch {
                        repo.saveTraining(training)
                        Toast.makeText(requireContext(), getString(R.string.success_training_saved), Toast.LENGTH_SHORT).show()
                    }
                }
            }
        }
    }
}