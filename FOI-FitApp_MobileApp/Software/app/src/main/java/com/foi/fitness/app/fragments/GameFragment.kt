package com.foi.fitness.app.fragments

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.fragment.app.Fragment
import com.foi.fitness.app.GameActivity
import com.foi.fitness.app.R

class GameFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_game, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val playButton = view.findViewById<Button>(R.id.btn_play)

        playButton.setOnClickListener {
            val intent = Intent(requireContext(), GameActivity::class.java)
            startActivity(intent)
        }

        childFragmentManager.beginTransaction()
            .replace(R.id.leaderboard_container, LeaderboardFragment())
            .commit()
    }
}