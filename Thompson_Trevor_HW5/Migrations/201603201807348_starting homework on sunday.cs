namespace Thompson_Trevor_HW5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startinghomeworkonsunday : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Event_EventID", "dbo.Events");
            DropIndex("dbo.Members", new[] { "Event_EventID" });
            CreateTable(
                "dbo.MemberEvents",
                c => new
                    {
                        Member_MemberID = c.Int(nullable: false),
                        Event_EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_MemberID, t.Event_EventID })
                .ForeignKey("dbo.Members", t => t.Member_MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_EventID, cascadeDelete: true)
                .Index(t => t.Member_MemberID)
                .Index(t => t.Event_EventID);
            
            AddColumn("dbo.Members", "Member_MemberID", c => c.Int());
            CreateIndex("dbo.Members", "Member_MemberID");
            AddForeignKey("dbo.Members", "Member_MemberID", "dbo.Members", "MemberID");
            DropColumn("dbo.Members", "Event_EventID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Event_EventID", c => c.Int());
            DropForeignKey("dbo.Members", "Member_MemberID", "dbo.Members");
            DropForeignKey("dbo.MemberEvents", "Event_EventID", "dbo.Events");
            DropForeignKey("dbo.MemberEvents", "Member_MemberID", "dbo.Members");
            DropIndex("dbo.MemberEvents", new[] { "Event_EventID" });
            DropIndex("dbo.MemberEvents", new[] { "Member_MemberID" });
            DropIndex("dbo.Members", new[] { "Member_MemberID" });
            DropColumn("dbo.Members", "Member_MemberID");
            DropTable("dbo.MemberEvents");
            CreateIndex("dbo.Members", "Event_EventID");
            AddForeignKey("dbo.Members", "Event_EventID", "dbo.Events", "EventID");
        }
    }
}
