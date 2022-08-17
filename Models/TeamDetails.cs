using System.Collections.Generic;
using Farhad_Apro.Enum;

namespace Farhad_Apro.Models
{
    public class TeamDetails
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public TeamStatus ApprovalStatusFromManager { get; set; }
        public TeamStatus ApprovalStatusFromDirector { get; set; }
        //public string ApprovedPersonId { get; set; }
        public virtual ICollection<TeamMembers> MemberDetails { get; set; }
    }
}