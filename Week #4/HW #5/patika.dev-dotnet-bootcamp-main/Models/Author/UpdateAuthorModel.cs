using System;

namespace WebApi.Models.Author
{
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }


    }
}
