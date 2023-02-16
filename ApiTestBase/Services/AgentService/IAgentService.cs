
namespace APITestBase.Services.AgentService;

public interface IAgentService
{
    public Task<ServiceResponse<List<AgentDto>>> GetAllAgents();
    
    public Task<ServiceResponse<AgentDto>> GetAgentFizzBuzz(int id);

    public Task<ServiceResponse<AgentDto>> GetAgent(int id);

    public Task<ServiceResponse<AgentDto>> AddAgent(NewAgentDto newAgent);
}