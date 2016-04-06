namespace Thompson_Trevor_HW5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Committees",
                c => new
                    {
                        CommitteeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CommitteeID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        Location = c.String(),
                        MembersOnly = c.Boolean(nullable: false),
                        SponsoringCommittee_CommitteeID = c.Int(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Committees", t => t.SponsoringCommittee_CommitteeID)
                .Index(t => t.SponsoringCommittee_CommitteeID);
            
            AddColumn("dbo.Members", "Event_EventID", c => c.Int());
            CreateIndex("dbo.Members", "Event_EventID");
            AddForeignKey("dbo.Members", "Event_EventID", "dbo.Events", "EventID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "SponsoringCommittee_CommitteeID", "dbo.Committees");
            DropForeignKey("dbo.Members", "Event_EventID", "dbo.Events");
            DropIndex("dbo.Members", new[] { "Event_EventID" });
            DropIndex("dbo.Events", new[] { "SponsoringCommittee_CommitteeID" });
            DropColumn("dbo.Members", "Event_EventID");
            DropTable("dbo.Events");
            DropTable("dbo.Committees");
        }
    }
}
