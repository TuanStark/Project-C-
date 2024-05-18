using Cake_shop.Models.Admin;
using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Models
{
    [Table("products")]
    public class ProductModel : BaseModel
    {
        public ProductModel() 
        { 
            this.OrdersDetails = new HashSet<OrdersDetails>();
            this.ProductImages = new HashSet<GaleryModels>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long CategoryId { get; set; }
        [StringLength(255)]
        public string title { get; set; }
        [StringLength(255)]
        public string description { get; set; }
        public double price { get; set; }
        public int discount { get; set; }
        [StringLength(255)]
        public string img {  get; set; }
        [StringLength(255)]
        public string ingredient { get; set; }
        [StringLength(255)]
        public string size { get; set; }
        public int weight { get; set; }
        public int quantity { get; set; }
        public bool status { get; set; }
        [StringLength(255)]
        public string note { get; set; }
        public bool hot { get; set; }
        [AllowHtml]
        public string content { get; set; }
        public bool new_product {  get; set; }
        public bool promotion_product { get; set; }
        public string alias { get; set; }
        public virtual CategoryModel Category { get; set; }
        public ICollection<GaleryModels> ProductImages { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<OrdersDetails> OrdersDetails { get; set; }

        public virtual ProductCategory ProductCategorys { get; set; }
    }
}