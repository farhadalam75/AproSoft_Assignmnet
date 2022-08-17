using System;

namespace Farhad_Apro.Models
{
    public class TeamMembers
    {
        public int Id { get; set; }
        public int TeamDetailsId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNo { get; set; }
        public virtual TeamDetails TeamDetails { get; set; }
    }
}