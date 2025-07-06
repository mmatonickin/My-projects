package com.foi.fitness.app.converters

import androidx.room.TypeConverter
import com.foi.fitness.app.models.enums.Genre

class GenreConverter {
    @TypeConverter
        fun fromGenre(genre: Genre): String {
            return genre.name
        }
    @TypeConverter
    fun toGenre(value: String): Genre {
        return Genre.valueOf(value)
    }

}