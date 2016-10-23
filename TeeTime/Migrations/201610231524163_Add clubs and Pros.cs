namespace TeeTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddclubsandPros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClubProes",
                c => new
                    {
                        ClubProId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        GolfClubId = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ClubProId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClubProes");
        }
    }
}
