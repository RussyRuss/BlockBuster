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
        public void GetMoviesByGenreDescr()
        {
            var directorlast = BlockBusterBasicFunctions.GetMoviesByGenreDescr("Action");
            Assert.True(directorlast.Count == 5);

        }

        [Fact]
        public void GetByDirectorsLast()
        {
            var result = BlockBusterBasicFunctions.GetByDirectorsLast("Eastwood");
            Assert.True(result.Count == 28);
        }






    }


}

    
