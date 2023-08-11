using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Data.Entity;

namespace WebApi.Entity
{
    [Table("Author", Schema = "dbo")]
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual List<Book> Books { get; set; }


    }
}
