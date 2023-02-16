
using APITestBase.Controllers;
using Moq;

namespace ApiTestBaseTests.AgentServiceTests.Controllers;

public class AgentControllerTests
{
    private readonly Mock<IAgentService> _agentServiceMock;

    public AgentControllerTests()
    {

    }

    [Fact]
    public void GetFizzBuzz_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange

        var sut = new AgentsController();

        // Act

        // Assert
    }
}
