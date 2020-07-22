namespace PhoneApplicationAssig.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "EmailId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "EmailId");
        }
    }
}
