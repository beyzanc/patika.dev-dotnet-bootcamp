using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using WebApi.Business.Application.AuthorOperations.GetAuthorDetail;
using WebApi.Data.DBOperations;
using WebApi.Models.Author;
using Xunit;

namespace Tests.Application.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQueryTest : IClassFixture<Common>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GetAuthorDetailQueryTest(Common test)
        {
            this.context = test.Context;
            this.mapper = test.Mapper;
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeReturned()
        {
            GetAuthorDetailQuery query = new(context, mapper);
            var AuthorId = query.AuthorId = 1;

            var author = context.Authors.Where(a => a.Id == AuthorId).SingleOrDefault();

            AuthorDetailViewModel model = query.Handle();

            model.Should().NotBeNull();
            model.FullName.Should().Be(author.Name + " " + author.Surname);
            model.BirthDate.Should().Be(author.BirthDate);
        }

        [Fact]
        public void WhenNonExistingAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            int authorId = 1234;

            GetAuthorDetailQuery query = new(context, mapper);
            query.AuthorId = authorId;

            query.Invoking(x => x.Handle())
                 .Should().Throw<InvalidOperationException>()
                 .And.Message.Should().Be("Author not found");
        }
    }
}
