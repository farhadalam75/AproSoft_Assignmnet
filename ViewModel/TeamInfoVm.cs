using System.Collections.Generic;
using Farhad_Apro.Models;

namespace Farhad_Apro.ViewModel
{
    public class TeamInfoVm
    {
        public string TeamName { get; set; }
        public string Description { get; set; }
        public List<TeamMembers> Details { get; set; }
    }
}