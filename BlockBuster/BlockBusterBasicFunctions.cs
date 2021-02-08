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

        public static List<Movie> GetGenreDescr()
        {
            using (var db = new SE407_blockBusterContext())
            {
                return db.Genre
                    .Join(db.Movies,
                    g => g.GenreId,
                    m => m.Genre.GenreId,
                    (g, m) => new
                    {
                        GenreId = m.GenreId,
                        GenreDescr = g.GenreDescr

                    }).Where(e => e.GenreDescr == "D")
                    .Select(m => new Movie
                    {
                        GenreId = m.GenreId,
                        
                    }).ToList();

            }
        }

        public static List<Movie> GetByDirectorsLast()
        {
            using (var db = new SE407_blockBusterContext())
            {
                return db.Directors
                    .Join(db.Movies,
                    d => d.DirectorId,
                    m => m.Director.DirectorId,
                    (m, d) => new
                    {
                        DirectorId = d.DirectorId,
                        LastName = m.LastName

                    }).Where(l => l.LastName == "L")
                    .Select(m => new Movie
                    {
                        DirectorId = m.DirectorId

                    }).ToList();

            }
        }


    }
}
