namespace Farhad_Apro.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        Description = c.String(),
                        TeamStatus = c.Int(nullable: false),
                        IsApprovedByManager = c.Boolean(nullable: false),
                        IsApprovedByDirector = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamDetailsId = c.Int(nullable: false),
                        Name = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ContactNo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeamDetails", t => t.TeamDetailsId, cascadeDelete: true)
                .Index(t => t.TeamDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamMembers", "TeamDetailsId", "dbo.TeamDetails");
            DropIndex("dbo.TeamMembers", new[] { "TeamDetailsId" });
            DropTable("dbo.TeamMembers");
            DropTable("dbo.TeamDetails");
        }
    }
}
