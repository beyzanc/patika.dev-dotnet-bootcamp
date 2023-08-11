using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Data.Entity;

namespace WebApi.Entity
{
    [Table("Genre", Schema = "dbo")]

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Book> Books { get; set; }




    }
}
