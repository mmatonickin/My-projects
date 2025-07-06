package com.foi.fitness.app.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.foi.fitness.app.R
import com.foi.fitness.app.models.unsplash.UnsplashPhoto
import com.squareup.picasso.Picasso

class UnsplashImageAdapter(
    private val onClick: (String) -> Unit
) : ListAdapter<UnsplashPhoto, UnsplashImageAdapter.ImageViewHolder>(DiffCallback()) {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ImageViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.fragment_item_unsplash_image, parent, false)
        return ImageViewHolder(view)
    }

    override fun onBindViewHolder(holder: ImageViewHolder, position: Int) {
        val photo = getItem(position)

        Picasso.get()
            .load(photo.urls.small)
            .fit()
            .centerCrop()
            .into(holder.imageView)

        holder.imageView.setOnClickListener {
            onClick(photo.urls.full)
        }
    }

    class ImageViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val imageView: ImageView = view.findViewById(R.id.iv_unsplash_image)
    }

    class DiffCallback : DiffUtil.ItemCallback<UnsplashPhoto>() {
        override fun areItemsTheSame(oldItem: UnsplashPhoto, newItem: UnsplashPhoto) =
            oldItem.id == newItem.id

        override fun areContentsTheSame(oldItem: UnsplashPhoto, newItem: UnsplashPhoto) =
            oldItem == newItem
    }
}