using System.Collections.Generic;
using Farhad_Apro.Models;
using Farhad_Apro.Repository.DB;
using Farhad_Apro.Repository.Interface;

namespace Farhad_Apro.Repository.Manager
{
    public class TeamMembersManager : GenericManager<TeamMembers>, ITeamMembersManager
    {
        public TeamMembersManager(ApplicationDbContext db) : base(new TeamMembersRepository(db))
        {

        }

         public TeamMembers GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);
        }

        public ICollection<TeamMembers> GetAll()
        {
            return Get(x => true);
        }

    }
}