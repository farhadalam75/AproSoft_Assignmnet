using Farhad_Apro.Models;
using Farhad_Apro.Repository.DB;
using Farhad_Apro.Repository.Interface;

namespace Farhad_Apro.Repository.Manager
{
    public class TeamMembersRepository : GenericRepository<TeamMembers>, ITeamMembersRepository
    {
        public TeamMembersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}