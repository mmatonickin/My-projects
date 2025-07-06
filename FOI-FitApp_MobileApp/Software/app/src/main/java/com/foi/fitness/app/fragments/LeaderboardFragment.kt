package com.foi.fitness.app.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.foi.fitness.app.R
import com.foi.fitness.app.adapters.ScoreAdapter
import com.foi.fitness.app.viewModels.LeaderboardViewModel

class LeaderboardFragment : Fragment() {

    private lateinit var viewModel: LeaderboardViewModel
    private lateinit var recyclerView: RecyclerView

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_leaderboard, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        recyclerView = view.findViewById(R.id.recyclerLeaderboard)
        recyclerView.layoutManager = LinearLayoutManager(requireContext())

        viewModel = ViewModelProvider(this)[LeaderboardViewModel::class.java]
        viewModel.loadTopScores()

        viewModel.scores.observe(viewLifecycleOwner) { scores ->
            recyclerView.adapter = ScoreAdapter(scores)
        }
    }
}