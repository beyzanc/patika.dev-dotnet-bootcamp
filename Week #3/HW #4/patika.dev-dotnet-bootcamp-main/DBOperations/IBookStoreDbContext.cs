using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entity;

namespace DB.DBOperations
{
    public interface IBookStoreDbContext
    {
        public DbSet<Book> Books { get; set; }

        int SaveChanges();
    }
}
