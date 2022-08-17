using System.Collections.Generic;
using Farhad_Apro.Models;

namespace Farhad_Apro.Repository.Interface
{
    interface ITeamMembersManager : IGenericManager<TeamMembers>
    {
        TeamMembers GetById(int id);
        ICollection<TeamMembers> GetAll();
    }
}