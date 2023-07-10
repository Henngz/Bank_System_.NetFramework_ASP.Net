namespace BankOfBIT_YZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColunmNameNextAvailableNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NextUniqueNumbers", "NextAvailableNumber", c => c.Long(nullable: false));
            DropColumn("dbo.NextUniqueNumbers", "NextAvailableNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NextUniqueNumbers", "NextAvailableNumber", c => c.Long(nullable: false));
            DropColumn("dbo.NextUniqueNumbers", "NextAvailableNumber");
        }
    }
}
