using APITestBase.Data;

namespace APITestBase.Services.SQLService;

public class SQLService : ISQLService
{
    private readonly DataContext _dataContext;
    public SQLService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAgent(Agent agent)
    {
       _dataContext.Agents.Add(agent);
       await _dataContext.SaveChangesAsync();
    }

    public async Task<Agent> GetAgentByName(string name)
    {
        var agent = await _dataContext.Agents.FirstOrDefaultAsync(c => c.Name.Equals(name));
        if (agent == null)
        {
            throw new Exception("Agent name not found");
        }

        return agent;
    }

    public async Task<Agent> GetAgentById(int id)
    {
        var agent = await _dataContext.Agents.FindAsync(id);
        return agent!;
    }

    public async Task<List<Agent>> GetAllAgents()
    {
        var dbAgents = await _dataContext.Agents.ToListAsync();
        return dbAgents;
    }
}