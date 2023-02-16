

using ApiTestBase.Services.AgentService;
using APITestBase.Services.SQLService;
using APITestOne;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using AutoFixture;

namespace ApiTestBaseTests.ApiTestBaseTests;

public class AgentServiceTests
{
    private readonly Mock<ILogger<AgentService>> _mockIloggerAgentService;
    private readonly Mock<ISQLService> _mockISQLService;
    private readonly IMapper _mapper;
    private static readonly Fixture _fixture = new Fixture();

    public AgentServiceTests()
    {
        _mockIloggerAgentService= new Mock<ILogger<AgentService>>();
        _mockISQLService= new Mock<ISQLService>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfiles());
        });
        _mapper = config.CreateMapper();

    }

    [Fact]
    private void When_Value_Is_Multiple_Of_Three_Then_Return_Fizz()
    {
        //Arrange
        int value = 3;

        var sut = new AgentService(_mockIloggerAgentService.Object, _mockISQLService.Object, _mapper);
        //Act

        var act = sut.GetFizzBuzz(value);

        //Assert

        act.Should().Be("Fizz");

    }


    [Fact]
    private void When_Value_Is_Multiple_Of_Five_Then_Return_Buzz()
    {
        //Arrange
        int value = 5;

        var sut = new AgentService(_mockIloggerAgentService.Object, _mockISQLService.Object, _mapper);
        //Act

        var act = sut.GetFizzBuzz(value);

        //Assert

        act.Should().Be("Buzz");

    }

    [Fact]
    private void When_Value_Is_Multiple_Of_Five_And_Three_Then_Return_FizzBuzz()
    {
        //Arrange
        int value = 15;

        var sut = new AgentService(_mockIloggerAgentService.Object, _mockISQLService.Object, _mapper);
        //Act

        var act = sut.GetFizzBuzz(value);

        //Assert

        act.Should().Be("FizzBuzz");

    }

    [Fact]
    private void When_Value_Is_not_Multiple_Of_Five_or_Three_Then_Return_The_Number()
    {
        //Arrange
        int value = 1;

        var sut = new AgentService(_mockIloggerAgentService.Object, _mockISQLService.Object, _mapper);
        //Act

        var act = sut.GetFizzBuzz(value);

        //Assert

        act.Should().Be(value.ToString());

    }

    [Theory]
    [InlineData(-1, "-1")]
    [InlineData(0, "FizzBuzz")]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(9, "Fizz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(25, "Buzz")]
    private void When_Value_Is_X_Then_FizzBuzz_Result_Is_Y(int value, string result)
    {
        //Arrange

        var sut = new AgentService(_mockIloggerAgentService.Object, _mockISQLService.Object, _mapper);

        //Act

        var act = sut.GetFizzBuzz(value);

        //Assert

        act.Should().Be(result);
    }

    [Theory]
    [InlineData(-1, "-1")]
    [InlineData(0, "FizzBuzz")]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(9, "Fizz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(25, "Buzz")]
    private void When_Value_Is_X_Then_FizzBuzz_Result_Is_Y_For_Static_Class(int value, string result)
    {
        //Act

        var act = FizzBuzz.GetFizzBuzz(value);

        //Assert

        act.Should().Be(result);
    }


    [Theory]
    [InlineData(-1, "-1")]
    [InlineData(0, "FizzBuzz")]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(9, "Fizz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(25, "Buzz")]
    private async Task When_Value_Is_not_Multiple_Of_Five_or_Three_On_GetAgentFizzBuzz_Then_FizzBuzz_Should_Be_The_Number(int value, string result)
    {
        //Arrange

        var agent = _fixture
            .Build<Agent>()
                .With(c => c.FizzBuzz, value)
                .Create();

        _mockISQLService.Setup(x => x.GetAgentById(It.IsAny<int>())).ReturnsAsync(agent);

        var sut = new AgentService(_mockIloggerAgentService.Object, _mockISQLService.Object, _mapper);
        //Act

        var act = await sut.GetAgentFizzBuzz(agent.Id);

        //Assert

        act.Success.Should().BeTrue();
        act.Message.Should().Be(string.Empty);
        act.Data.Should().NotBeNull();
        act.Data.FizzBuzzValue.Should().Be(result);

    }
}

