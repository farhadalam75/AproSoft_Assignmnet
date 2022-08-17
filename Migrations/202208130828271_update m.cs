namespace Farhad_Apro.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class updatem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeamDetails", "IsActive", c => c.String());
            AddColumn("dbo.TeamDetails", "ApprovalStatusFromManager", c => c.Int(nullable: false));
            AddColumn("dbo.TeamDetails", "ApprovalStatusFromDirector", c => c.Int(nullable: false));
            DropColumn("dbo.TeamDetails", "TeamStatus");
            DropColumn("dbo.TeamDetails", "IsApprovedByManager");
            DropColumn("dbo.TeamDetails", "IsApprovedByDirector");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeamDetails", "IsApprovedByDirector", c => c.Boolean(nullable: false));
            AddColumn("dbo.TeamDetails", "IsApprovedByManager", c => c.Boolean(nullable: false));
            AddColumn("dbo.TeamDetails", "TeamStatus", c => c.Int(nullable: false));
            DropColumn("dbo.TeamDetails", "ApprovalStatusFromDirector");
            DropColumn("dbo.TeamDetails", "ApprovalStatusFromManager");
            DropColumn("dbo.TeamDetails", "IsActive");
        }
    }
}
