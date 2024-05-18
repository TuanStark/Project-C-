namespace Cake_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAdmin2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.admin", "email", c => c.String(maxLength: 50));
            DropColumn("dbo.admin", "émail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.admin", "émail", c => c.String(maxLength: 50));
            DropColumn("dbo.admin", "email");
        }
    }
}
