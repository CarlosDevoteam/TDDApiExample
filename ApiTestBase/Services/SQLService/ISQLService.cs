namespace APITestBase.Services.SQLService;

public interface ISQLService
{
    public Task<Agent> GetAgentById (int id);

    public Task<Agent> GetAgentByName (string name);

    public Task<List<Agent>> GetAllAgents();

    public Task AddAgent(Agent agent);
}
