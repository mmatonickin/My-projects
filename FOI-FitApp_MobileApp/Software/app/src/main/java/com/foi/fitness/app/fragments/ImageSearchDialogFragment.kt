package com.foi.fitness.app.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.fragment.app.DialogFragment
import androidx.fragment.app.viewModels
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.foi.fitness.app.R
import com.foi.fitness.app.adapters.UnsplashImageAdapter
import com.foi.fitness.app.viewModels.UnsplashViewModel

class ImageSearchDialogFragment : DialogFragment() {

    private val viewModel: UnsplashViewModel by viewModels()
    private var onImageSelected: ((String) -> Unit)? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        retainInstance = true
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View = inflater.inflate(R.layout.fragment_dialog_image_search, container, false)

    override fun onStart() {
        super.onStart()
        dialog?.window?.setLayout(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        val searchInput = view.findViewById<EditText>(R.id.search_input)
        val searchBtn = view.findViewById<Button>(R.id.search_button)
        val recyclerView = view.findViewById<RecyclerView>(R.id.recycler_view)

        val adapter = UnsplashImageAdapter { imageUrl ->
            onImageSelected?.invoke(imageUrl)
            dismissAllowingStateLoss()
        }

        recyclerView.layoutManager = LinearLayoutManager(requireContext())
        recyclerView.adapter = adapter

        searchBtn.setOnClickListener {
            val query = searchInput.text.toString().trim()
            if (query.isEmpty()) {
                Toast.makeText(requireContext(), getString(R.string.enter_search_query), Toast.LENGTH_SHORT).show()
            } else {
                viewModel.searchPhotos(query)
            }
        }

        viewModel.photos.observe(viewLifecycleOwner) {
            adapter.submitList(it)
        }

        viewModel.error.observe(viewLifecycleOwner) { error ->
            error?.let {
                Toast.makeText(requireContext(), "Error: $it", Toast.LENGTH_LONG).show()
            }
        }
    }

    fun setOnImageSelectedListener(listener: (String) -> Unit) {
        onImageSelected = listener
    }
}