namespace Farhad_Apro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesmade : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TeamDetails", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeamDetails", "IsActive", c => c.String());
        }
    }
}
