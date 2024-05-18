namespace Cake_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CraeteData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admin",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Roles_id = c.Long(nullable: false),
                        username = c.String(maxLength: 50),
                        password = c.String(maxLength: 50),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.role", t => t.Roles_id, cascadeDelete: true)
                .Index(t => t.Roles_id);
            
            CreateTable(
                "dbo.role",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 255),
                        code = c.String(maxLength: 255),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        fullname = c.String(maxLength: 100),
                        email = c.String(maxLength: 100),
                        password = c.String(maxLength: 100),
                        phone = c.String(maxLength: 12),
                        address = c.String(maxLength: 100),
                        status = c.Int(nullable: false),
                        Roles_id = c.Long(nullable: false),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.comment",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Users_id = c.Long(nullable: false),
                        Products_id = c.Long(nullable: false),
                        content = c.String(maxLength: 255),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.products", t => t.Products_id, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.Users_id, cascadeDelete: true)
                .Index(t => t.Users_id)
                .Index(t => t.Products_id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        CategoryId = c.Long(nullable: false),
                        title = c.String(maxLength: 255),
                        description = c.String(maxLength: 255),
                        price = c.Double(nullable: false),
                        discount = c.Int(nullable: false),
                        img = c.String(maxLength: 255),
                        ingredient = c.String(maxLength: 255),
                        size = c.String(maxLength: 255),
                        weight = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                        note = c.String(maxLength: 255),
                        hot = c.Boolean(nullable: false),
                        content = c.String(),
                        new_product = c.Boolean(nullable: false),
                        promotion_product = c.Boolean(nullable: false),
                        alias = c.String(),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                        ProductCategorys_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.productcategory", t => t.ProductCategorys_id)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductCategorys_id);
            
            CreateTable(
                "dbo.category",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        img = c.String(nullable: false, maxLength: 255),
                        name = c.String(nullable: false, maxLength: 255),
                        alias = c.String(),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.orders_details",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Oders_id = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        price = c.Double(nullable: false),
                        quantity = c.Int(nullable: false),
                        total_money = c.Double(nullable: false),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                        Oders_id1 = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.orders", t => t.Oders_id1)
                .ForeignKey("dbo.products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.Oders_id1);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Users_id = c.Long(nullable: false),
                        fullName = c.String(maxLength: 255),
                        email = c.String(maxLength: 50),
                        phone = c.String(maxLength: 12),
                        address = c.String(maxLength: 50),
                        status = c.Int(nullable: false),
                        note = c.String(maxLength: 255),
                        order_date = c.DateTime(nullable: false),
                        total_money = c.Single(nullable: false),
                        payment_methods = c.Int(nullable: false),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.Users_id, cascadeDelete: true)
                .Index(t => t.Users_id);
            
            CreateTable(
                "dbo.productcategory",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(maxLength: 255),
                        icon = c.String(maxLength: 255),
                        seotitle = c.String(maxLength: 255),
                        seodescription = c.String(maxLength: 255),
                        seokeywwords = c.String(maxLength: 255),
                        alias = c.String(maxLength: 255),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.galery",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Products_id = c.Long(nullable: false),
                        thumbnail = c.String(maxLength: 255),
                        isDefault = c.Boolean(nullable: false),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.products", t => t.Products_id, cascadeDelete: true)
                .Index(t => t.Products_id);
            
            CreateTable(
                "dbo.menu",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        link = c.String(),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.news",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        title = c.String(maxLength: 255),
                        content = c.String(),
                        sumary = c.String(maxLength: 255),
                        img = c.String(maxLength: 255),
                        alias = c.String(),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.post",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        title = c.String(maxLength: 255),
                        description = c.String(maxLength: 255),
                        alias = c.String(maxLength: 255),
                        detail = c.String(),
                        image = c.String(maxLength: 255),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.slides",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        img = c.String(maxLength: 255),
                        createDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        createBy = c.String(),
                        modifiledBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserModelRoles",
                c => new
                    {
                        UserModel_id = c.Long(nullable: false),
                        Role_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserModel_id, t.Role_id })
                .ForeignKey("dbo.user", t => t.UserModel_id, cascadeDelete: true)
                .ForeignKey("dbo.role", t => t.Role_id, cascadeDelete: true)
                .Index(t => t.UserModel_id)
                .Index(t => t.Role_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModelRoles", "Role_id", "dbo.role");
            DropForeignKey("dbo.UserModelRoles", "UserModel_id", "dbo.user");
            DropForeignKey("dbo.comment", "Users_id", "dbo.user");
            DropForeignKey("dbo.galery", "Products_id", "dbo.products");
            DropForeignKey("dbo.products", "ProductCategorys_id", "dbo.productcategory");
            DropForeignKey("dbo.orders_details", "ProductId", "dbo.products");
            DropForeignKey("dbo.orders", "Users_id", "dbo.user");
            DropForeignKey("dbo.orders_details", "Oders_id1", "dbo.orders");
            DropForeignKey("dbo.comment", "Products_id", "dbo.products");
            DropForeignKey("dbo.products", "CategoryId", "dbo.category");
            DropForeignKey("dbo.admin", "Roles_id", "dbo.role");
            DropIndex("dbo.UserModelRoles", new[] { "Role_id" });
            DropIndex("dbo.UserModelRoles", new[] { "UserModel_id" });
            DropIndex("dbo.galery", new[] { "Products_id" });
            DropIndex("dbo.orders", new[] { "Users_id" });
            DropIndex("dbo.orders_details", new[] { "Oders_id1" });
            DropIndex("dbo.orders_details", new[] { "ProductId" });
            DropIndex("dbo.products", new[] { "ProductCategorys_id" });
            DropIndex("dbo.products", new[] { "CategoryId" });
            DropIndex("dbo.comment", new[] { "Products_id" });
            DropIndex("dbo.comment", new[] { "Users_id" });
            DropIndex("dbo.admin", new[] { "Roles_id" });
            DropTable("dbo.UserModelRoles");
            DropTable("dbo.slides");
            DropTable("dbo.post");
            DropTable("dbo.news");
            DropTable("dbo.menu");
            DropTable("dbo.galery");
            DropTable("dbo.productcategory");
            DropTable("dbo.orders");
            DropTable("dbo.orders_details");
            DropTable("dbo.category");
            DropTable("dbo.products");
            DropTable("dbo.comment");
            DropTable("dbo.user");
            DropTable("dbo.role");
            DropTable("dbo.admin");
        }
    }
}
