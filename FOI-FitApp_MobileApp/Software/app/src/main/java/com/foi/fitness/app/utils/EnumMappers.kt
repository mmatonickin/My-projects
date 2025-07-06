package com.foi.fitness.app.utils

import com.foi.fitness.app.models.enums.Genre

fun String?.toGenre(): Genre {
    return this?.trim()?.let { input ->
        Genre.entries.firstOrNull {
            it.name.equals(input, ignoreCase = true)
        }
    } ?: Genre.Undefined
}

