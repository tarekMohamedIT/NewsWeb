namespace NewsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedValidators : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String());
        }
    }
}
