using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Business.Application.AuthorOperations.UpdateAuthor;
using WebApi.Data.DBOperations;
using WebApi.Entity;
using WebApi.Models.Author;
using Xunit;

namespace Tests.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandTest : IClassFixture<Common>
    {
        private readonly BookStoreDbContext context;

        public UpdateAuthorCommandTest(Common test)
        {
            this.context = test.Context;
        }

        [Fact]
        public void WhenGivenAuthorIsNotFound_InvalidOperationException_ShouldBeReturn()
        {

            UpdateAuthorCommand command = new(context);
            command.AuthorId = 1234;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author not found to update.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeUpdated()
        {
            UpdateAuthorCommand command = new(context);
            var author = new Author { Name = "Peyami", Surname = "Safa", BirthDate = new DateTime(1940, 01, 01) };

            context.Authors.Add(author);
            context.SaveChanges();

            command.AuthorId = author.Id;
            UpdateAuthorModel model = new UpdateAuthorModel { Name = "Halide Edip", Surname = "Adıvar", BirthDate = new DateTime(2000, 01, 02) };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();
           
            var updatedAuthor = context.Authors.SingleOrDefault(a => a.Id == author.Id);
          
            updatedAuthor.Should().NotBeNull();
            updatedAuthor.Name.Should().Be(model.Name);
            updatedAuthor.Surname.Should().Be(model.Surname);
            updatedAuthor.BirthDate.Should().Be(model.BirthDate);

        }
    }
}
