using FluentAssertions;
using System;
using System.Linq;
using WebApi.Business.Application.AuthorOperations.DeleteAuthor;
using WebApi.Data.DBOperations;
using WebApi.Entity;
using Xunit;

namespace Tests.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommandTest : IClassFixture<Common>
    {
        private readonly BookStoreDbContext context;

        public DeleteAuthorCommandTest(Common test)
        {
            this.context = test.Context;
        }

        [Fact]
        public void WhenGivenAuthorIsNotFound_InvalidOperationException_ShouldBeReturn()
        {

            DeleteAuthorCommand command = new(context);
            command.AuthorId = 555;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("The author was not found to delete!");
        }

        [Fact]
        public void WhenGivenAuthorHaveBook_InvalidOperationException_ShouldBeReturn()
        {

            DeleteAuthorCommand command = new(context);
            command.AuthorId = 1;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("It can not be deleted the author who has book.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeDeleted()
        {
            var newAuthor = new Author()
            {
                Name = "Beyza",
                Surname = "Cabuk",
                BirthDate = new DateTime(1996, 04, 25)
            };
            context.Authors.Add(newAuthor);
            context.SaveChanges();

            DeleteAuthorCommand command = new(context);
            command.AuthorId = newAuthor.Id;

            FluentActions.Invoking(() => command.Handle()).Invoke();
    
            var author = context.Authors.SingleOrDefault(a => a.Id == command.AuthorId);
            author.Should().BeNull();
        }
    }
}
