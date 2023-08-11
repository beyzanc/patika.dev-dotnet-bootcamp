using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Business.Application.AuthorOperations.GetAuthors;
using WebApi.Data.DBOperations;
using Xunit;

namespace Tests.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQueryTest : IClassFixture<Common>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GetAuthorsQueryTest(Common test)
        {
            this.context = test.Context;
            this.mapper = test.Mapper;
        }

        [Fact]
        public void WhenGetAuthorsQueryIsHandled_AuthorListShouldBeReturned()
        {
            var query = new GetAuthorsQuery(context, mapper);

            var result = query.Handle();
            var resultList = result.ToList();

            resultList.Should().NotBeNull();
            resultList.Should().HaveCount(3);

            resultList[0].Name.Should().Be("Mark");
            resultList[0].Name.Should().Be("Wolynn");

            resultList[1].Name.Should().Be("Andre");
            resultList[1].Surname.Should().Be("Gide");


            resultList[2].Name.Should().Be("Thomas");
            resultList[2].Surname.Should().Be("Schramme");

        }
    }
}
