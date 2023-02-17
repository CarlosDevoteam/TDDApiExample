namespace ApiTestBaseTests;

using APITestBase.Models;
using APITestBase.Services.AgentService;
using APITestBase.Services.SQLService;
using APITestOne;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
public class AgentServiceTest
{
    private readonly Fixture _fixture = new Fixture();
    private readonly Mock<ILogger<AgentService>> _mockLogger;
    private readonly IMapper _imapper;
    private readonly Mock<ISQLService> _mockSqlService;
    public AgentServiceTest()
    {
        _mockLogger = new Mock<ILogger<AgentService>>();
        _mockSqlService = new Mock<ISQLService>();
        var config = new MapperConfiguration(c => c.AddProfile(new AutoMapperProfiles()));
        _imapper = config.CreateMapper();
    }
    [Fact]
    public void WhenValueIsMultipleOfThreeThenReturnFizz()
    {
        // Arrange
        var value = 3;
        //var result = new AgentService();
        // Act
        var act = GetFizzBuzzHelper.GetFizzBuzz(value);
        // Asset
        act.Should().Be("Fizz");
    }
    [Fact]
    public void WhenValueIsMultipleOfFiveThenReturnBuzz()
    {
        // Arrange
        var value = 5;
        //var result = new AgentService();
        // Act
        var act = GetFizzBuzzHelper.GetFizzBuzz(value);
        // Asset
        act.Should().Be("Buzz");
    }
    [Fact]
    public void WhenValueIsMultipleOfFiveAndThreeThenReturnFizzBuzz()
    {
        // Arrange
        var value = 15;
        //var result = new AgentService();
        // Act
        var act = GetFizzBuzzHelper.GetFizzBuzz(value);
        // Asset
        act.Should().Be("FizzBuzz");
    }
    [Fact]
    public void WhenValueNotMultipleOfFiveOrThreeThenReturnNumber()
    {
        // Arrange
        var value = 7;
        //var result = new AgentService();
        // Act
        var act = GetFizzBuzzHelper.GetFizzBuzz(value);
        // Asset
        act.Should().Be(value.ToString());
    }
    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(7, "7")]
    public void WhenValueIsXThenFizzBuzzResultIsY(int value, string result)
    {
        // Act
        var act = GetFizzBuzzHelper.GetFizzBuzz(value);
        // Asset
        act.Should().Be(result);
    }
    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(7, "7")]
    public async Task WhenValueIsXThenFizzBuzzResultIsYForAgentService(int value, string result)
    {
        // Arrange
        var agentserviceFixture = _fixture.Build<Agent>()
                                          .With(a => a.FizzBuzz, value)
                                          .Create();
        _mockSqlService.Setup(s => s.GetAgentById(It.IsAny<int>())).ReturnsAsync(agentserviceFixture);
        var resultAs = new AgentService(_mockLogger.Object, _mockSqlService.Object, _imapper);
        // Act
        var act = await resultAs.GetAgentFizzBuzz(value);
        // Asset
        act.Success.Should().BeTrue();
        act.Data.FizzBuzzValue.Should().Be(result);
    }
}