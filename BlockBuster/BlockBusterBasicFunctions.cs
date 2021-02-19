using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BlockBuster.Models;

namespace BlockBuster
{

    public class BlockBusterBasicFunctions
    {
        public static Movie GetMovieById(int id)
        {
            using (var db = new SE407_blockBusterContext())
            {
                return db.Movies.Find(id);
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using (var db = new SE407_blockBusterContext())
            {
                return db.Movies.ToList();
            }
        }


        public static List<Movie> GetAllCheckedOutMovies()
        {
            using (var db = new SE407_blockBusterContext())
            {
                return db.Movies
                    .Join(db.Transactions,
                    m => m.MovieId,
                    t => t.Movie.MovieId,
                    (m, t) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,
                        CheckedIn = t.CheckedIn

                    }).Where(w => w.CheckedIn == "N")
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,

                    }).ToList();

            }
        }

        public static List<Movie> GetMoviesByGenreDescr(string genreDescr)
        {
            using (var db = new SE407_blockBusterContext())
            {
                return db.Movies
                    .Join(db.Genres,
                    m => m.GenreId,
                    g => g.GenreId,
                    (m, g) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,
                        genre = g.GenreDescr

                    }).Where(w => w.genre == genreDescr)
                    .Select(m =>  new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,

                    }).ToList();

            }
        }

        public static List<Movie> GetByDirectorsLast(string directorsLast )
        {
            using (var db = new SE407_blockBusterContext())
            {
                return db.Movies
                    .Join(db.Directors,
                    m => m.DirectorId,
                    d => d.DirectorId,
                    (m, d) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,
                        director = d.LastName


                    }).Where(w => w.director == directorsLast)
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,

                    }).ToList();

            }
        }


    }
}
