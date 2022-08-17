using System.Collections.Generic;
using Farhad_Apro.Models;

namespace Farhad_Apro.Repository.Interface
{
    interface ITeamDetailsManager : IGenericManager<TeamDetails>
    {
        TeamDetails GetById(int id);
        ICollection<TeamDetails> GetAll();
    }
}