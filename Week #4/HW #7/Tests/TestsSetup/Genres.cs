using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.DBOperations;

namespace Tests.TestsSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange
                (
                    new WebApi.Entity.Genre
                    {
                        Name = "Poem"
                    },
                    new WebApi.Entity.Genre
                    {
                        Name = "Engineering"
                    },
                    new WebApi.Entity.Genre
                    {
                        Name = "Romance"
                    }
                );
        }
    }
}
