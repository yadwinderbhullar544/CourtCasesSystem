namespace CourtCasesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HearingMsts", "CurrentDate", c => c.String());
            AlterColumn("dbo.HearingMsts", "NextDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HearingMsts", "NextDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HearingMsts", "CurrentDate", c => c.DateTime(nullable: false));
        }
    }
}
