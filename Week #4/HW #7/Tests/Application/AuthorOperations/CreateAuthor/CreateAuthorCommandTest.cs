using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using WebApi.Business.Application.AuthorOperations.CreateAuthor;
using WebApi.Data.DBOperations;
using WebApi.Entity;
using Xunit;
using WebApi.Models.Author;

namespace Tests.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandTest : IClassFixture<Common>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public CreateAuthorCommandTest(Common test)
        {
            this.context = test.Context;
            this.mapper = test.Mapper;
        }

        [Fact]
        public void WhenAlreadyExitsAuthorFullNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var author = new Author()
            {
                Name = "Beyza",
                Surname = "Cabuk",
                BirthDate = new DateTime(1994, 08, 07)
            };
            context.Authors.Add(author);
            context.SaveChanges();

            CreateAuthorCommand command = new(context, mapper);
            command.Model = new CreateAuthorModel { Name = author.Name, Surname = author.Surname, BirthDate = author.BirthDate };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("That Author already exists");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            CreateAuthorCommand command = new(context, mapper);
            CreateAuthorModel model = new CreateAuthorModel()
            {
                Name = "Elif",
                Surname = "Cabuk",
                BirthDate = new DateTime(2995, 06, 09)
            };

            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var author = context.Authors.SingleOrDefault(g => g.Name == model.Name);
            author.Should().NotBeNull();
            author.Name.Should().Be(model.Name);
            author.Surname.Should().Be(model.Surname);
            author.BirthDate.Should().Be(model.BirthDate);
        }
    }
}
