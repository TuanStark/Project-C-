namespace Cake_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.user", "status", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.user", "status", c => c.Int(nullable: false));
        }
    }
}
