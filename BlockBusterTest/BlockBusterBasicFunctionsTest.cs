using System;
using System.Collections.Generic;
using System.Text;
using BlockBuster;
using BlockBusterTest;
using Xunit;

namespace BlockBusterTest
{

    public class BlockBusterBasicFunctionsTest
    {
        [Fact]
        public void GetMovieByIdTest()
        {
            var result = BlockBusterBasicFunctions.GetMovieById(11);
            Assert.True(result.Title == "Vertigo");
            Assert.True(result.ReleaseYear == 1958);
        }
        [Fact]
        public void GetAllMovies()
        {
            var result = BlockBusterBasicFunctions.GetAllMovies();
            Assert.True(result.Count == 50);
        }

        [Fact]
        public void GetAllCheckedOutMovies()
        {
            var result = BlockBusterBasicFunctions.GetAllCheckedOutMovies();
            Assert.True(result.Count == 3);
        }
        [Fact]
        public void GetGenres()
        {
            var result = BlockBusterBasicFunctions.GetGenre(11);
            Assert.True(result.GenreDescr == "Vertigo");
          
        }
        [Fact]
        public void GetDirectorsLast()
        {
            var result = BlockBusterBasicFunctions.GetDirectorsLast();
            Assert.True(result.Count == 50);
        }






    }


}

    
