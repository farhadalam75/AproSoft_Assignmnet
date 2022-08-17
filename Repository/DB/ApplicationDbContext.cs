using System.Data.Entity;
using Farhad_Apro.Models;

namespace Farhad_Apro.Repository.DB
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<TeamMembers> TeamMembers { get; set; }
        public DbSet<TeamDetails> TeamDetails { get; set; }
    }
}