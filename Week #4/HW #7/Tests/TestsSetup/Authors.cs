using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.DBOperations;
using WebApi.Entity;

namespace Tests.TestsSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                    new Author
                    {
                        Name = "Mark",
                        Surname = "Wolynn",
                        BirthDate = new DateTime(1968, 03, 16)
                    },
                     new Author
                     {
                         Name = "Andre",
                         Surname = "Gide",
                         BirthDate = new DateTime(1888, 11, 27)
                     },
                     new Author
                     {
                         Name = "Thomas",
                         Surname = "Schramme",
                         BirthDate = new DateTime(1933, 05, 21)
                     }
                );
        }
    }
}
