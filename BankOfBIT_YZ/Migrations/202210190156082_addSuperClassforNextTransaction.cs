namespace BankOfBIT_YZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSuperClassforNextTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        InstitutionId = c.Int(nullable: false, identity: true),
                        InstitutionNumber = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Payees",
                c => new
                    {
                        PayeeId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PayeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payees");
            DropTable("dbo.Institutions");
        }
    }
}
