using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entity;

namespace WebApi.Data.Entity
{
    [Table("Book", Schema = "dbo")]
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }


        public Genre Genre { get; set; }
        public Author Author { get; set; }



    }
}
