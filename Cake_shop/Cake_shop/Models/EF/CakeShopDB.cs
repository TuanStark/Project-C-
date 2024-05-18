using Cake_shop.Models.Admin;

using System.Data.Entity;


namespace Cake_shop.Models.EF
{
    public class CakeShopDB : DbContext
    {
        public CakeShopDB() : base("name=ConnectionStr") 
        {
        }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<GaleryModels> Galerys { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<NewsModel> News { get; set; }
        public DbSet<OdersModel> Orsers { get; set; }
        public DbSet<OrdersDetails> OrderDetails { get; set; }
        public DbSet<Slides> Slide { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AminModel> Amdins { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }

   

}