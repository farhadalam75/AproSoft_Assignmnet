using Farhad_Apro.Models;
using Farhad_Apro.Repository.DB;
using Farhad_Apro.Repository.Interface;

namespace Farhad_Apro.Repository.Manager
{
    public class TeamDetailsRepository: GenericRepository<TeamDetails>, ITeamDetailsRepository
    {
        public TeamDetailsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}