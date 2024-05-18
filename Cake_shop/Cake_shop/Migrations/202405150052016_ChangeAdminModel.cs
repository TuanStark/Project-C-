namespace Cake_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAdminModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.admin", "émail", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.admin", "émail");
        }
    }
}
