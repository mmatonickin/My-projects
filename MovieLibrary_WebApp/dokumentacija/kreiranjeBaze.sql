-- Creator:       MySQL Workbench 8.0.36/ExportSQLite Plugin 0.1.0
-- Author:        Unknown
-- Caption:       New Model
-- Project:       Name of the project
-- Changed:       2025-01-02 01:12
-- Created:       2024-12-14 17:06

-- Schema: RWA2024mmatonick22
BEGIN;
CREATE TABLE "role"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "role" VARCHAR(20) NOT NULL,
  CONSTRAINT "uloga_UNIQUE"
    UNIQUE("role")
);
CREATE TABLE "genre"(
  "id" INTEGER PRIMARY KEY NOT NULL,
  "name" VARCHAR(45) NOT NULL
);
CREATE TABLE "user"(
  "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "name" VARCHAR(30),
  "surname" VARCHAR(45),
  "email" VARCHAR(60) NOT NULL,
  "username" VARCHAR(45) NOT NULL,
  "password" VARCHAR(45) NOT NULL,
  "role_id" INTEGER NOT NULL,
  CONSTRAINT "username_UNIQUE"
    UNIQUE("username"),
  CONSTRAINT "fk_user_role1"
    FOREIGN KEY("role_id")
    REFERENCES "role"("id")
);
CREATE INDEX "user.fk_user_role1_idx" ON "user" ("role_id");
CREATE TABLE "movie"(
  "adult" INTEGER,
  "backdrop_path" VARCHAR(250),
  "id" INTEGER PRIMARY KEY NOT NULL,
  "original_language" VARCHAR(45),
  "original_title" VARCHAR(70) NOT NULL,
  "overview" TEXT,
  "popularity" INTEGER,
  "poster_path" VARCHAR(150),
  "release_date" DATE,
  "title" VARCHAR(45),
  "video" INTEGER,
  "vote_average" INTEGER,
  "vote_count" INTEGER,
  "user_id" INTEGER NOT NULL,
  CONSTRAINT "user_id"
    FOREIGN KEY("user_id")
    REFERENCES "user"("id")
);
CREATE INDEX "movie.user_id_idx" ON "movie" ("user_id");
CREATE TABLE "movieGenre"(
  "movie_id" INTEGER NOT NULL,
  "genre_id" INTEGER NOT NULL,
  PRIMARY KEY("movie_id","genre_id"),
  CONSTRAINT "fk_movie/genre_movie1"
    FOREIGN KEY("movie_id")
    REFERENCES "movie"("id")
    ON DELETE CASCADE,
  CONSTRAINT "fk_movie/genre_genre1"
    FOREIGN KEY("genre_id")
    REFERENCES "genre"("id")
);
CREATE INDEX "movieGenre.fk_movie/genre_genre1_idx" ON "movieGenre" ("genre_id");
COMMIT;
