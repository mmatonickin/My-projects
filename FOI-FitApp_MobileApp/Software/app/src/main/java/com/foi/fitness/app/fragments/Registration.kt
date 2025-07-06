package com.foi.fitness.app.fragments

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.RadioButton
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import com.foi.fitness.app.LoginActivity
import com.foi.fitness.app.R
import com.foi.fitness.app.database.AppDatabase
import com.foi.fitness.app.entities.User
import com.foi.fitness.app.models.enums.Genre
import com.foi.fitness.app.repositories.UserRepository
import com.foi.fitness.app.utils.UserInputValidators
import com.foi.fitness.app.viewModels.RegisterViewModel
import com.foi.fitness.app.viewModels.RegisterViewModelFactory

class RegistrationFragment : Fragment() {

    private lateinit var viewModel: RegisterViewModel

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        return inflater.inflate(R.layout.fragment_registration, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        AppDatabase.buildInstance(requireContext())
        val database = AppDatabase.getInstance()
        val repository = UserRepository(database.getUsersDao())
        val factory = RegisterViewModelFactory(repository)
        viewModel = ViewModelProvider(this, factory)[RegisterViewModel::class.java]

        val nameEt = view.findViewById<EditText>(R.id.name_et)
        val surnameEt = view.findViewById<EditText>(R.id.surname_et)
        val weightEt = view.findViewById<EditText>(R.id.weight_et)
        val heightEt = view.findViewById<EditText>(R.id.height_et)
        val ageEt = view.findViewById<EditText>(R.id.age_et)
        val emailEt = view.findViewById<EditText>(R.id.email_et)
        val usernameEt = view.findViewById<EditText>(R.id.username_et)
        val passwordEt = view.findViewById<EditText>(R.id.password_et)
        val radioMale = view.findViewById<RadioButton>(R.id.radio_male)
        val radioFemale = view.findViewById<RadioButton>(R.id.radio_female)
        val registerBtn = view.findViewById<Button>(R.id.RegisterUser)

        registerBtn.setOnClickListener {
            val name = nameEt.text.toString()
            val surname = surnameEt.text.toString()
            val weight = weightEt.text.toString().toIntOrNull()
            val height = heightEt.text.toString().toIntOrNull()
            val age = ageEt.text.toString().toIntOrNull()
            val email = emailEt.text.toString()
            val username = usernameEt.text.toString()
            val password = passwordEt.text.toString()

            val genre = when {
                radioFemale.isChecked -> Genre.Female
                radioMale.isChecked -> Genre.Male
                else -> Genre.Undefined
            }

            val validInput =
                UserInputValidators.isNameValid(name) &&
                        UserInputValidators.isSurnameValid(surname) &&
                        UserInputValidators.isWeightValid(weight) &&
                        UserInputValidators.isHeightValid(height) &&
                        UserInputValidators.isAgeValid(age) &&
                        UserInputValidators.isEmailValid(email) &&
                        UserInputValidators.isUsernameValid(username) &&
                        UserInputValidators.isPasswordValid(password)

            if (!validInput) {
                Toast.makeText(requireContext(), getString(R.string.registration_error_invalid_data), Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }

            val user = User(
                userId = 0,
                name = name,
                surname = surname,
                weight = weight!!,
                height = height!!,
                age = age!!,
                genre = genre,
                email = email,
                username = username,
                password = password,
                highScore = null
            )

            viewModel.register(user)
        }

        viewModel.registrationResult.observe(viewLifecycleOwner) { success ->
            when (success) {
                true -> {
                    Toast.makeText(requireContext(), getString(R.string.registration_success), Toast.LENGTH_SHORT).show()
                    val intent = Intent(requireContext(), LoginActivity::class.java)
                    intent.putExtra("registration_success", true)
                    startActivity(intent)
                    activity?.finish()
                }

                false -> {
                    Toast.makeText(requireContext(), getString(R.string.registration_error_username_exist), Toast.LENGTH_SHORT).show()
                }

                else -> {
                    Toast.makeText(requireContext(), getString(R.string.registration_error_unknown_exception), Toast.LENGTH_SHORT).show()
                }
            }
        }
    }
}
