using System.Collections.Generic;
using Farhad_Apro.Models;
using Farhad_Apro.Repository.DB;
using Farhad_Apro.Repository.Interface;

namespace Farhad_Apro.Repository.Manager
{
    public class TeamDetailsManager : GenericManager<TeamDetails>, ITeamDetailsManager
    {
        public TeamDetailsManager(ApplicationDbContext db) : base(new TeamDetailsRepository(db))
        {

        }

         public TeamDetails GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);
        }

        public ICollection<TeamDetails> GetAll()
        {
            return Get(x => x.IsActive);
        }

    }
}