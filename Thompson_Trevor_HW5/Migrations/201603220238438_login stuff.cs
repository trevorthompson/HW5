namespace Thompson_Trevor_HW5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginstuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Member_MemberID", "dbo.Members");
            DropIndex("dbo.Members", new[] { "Member_MemberID" });
            DropColumn("dbo.Members", "Member_MemberID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Member_MemberID", c => c.Int());
            CreateIndex("dbo.Members", "Member_MemberID");
            AddForeignKey("dbo.Members", "Member_MemberID", "dbo.Members", "MemberID");
        }
    }
}
