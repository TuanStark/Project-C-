using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cake_shop.Models.EF
{
    [Table("productcategory")]
    public class ProductCategory : BaseModel
    {
       
        public ProductCategory() 
        {
            this.Products = new HashSet<ProductModel>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string title { get; set; }
        [StringLength(255)]
        public string description { get; set; }
        [StringLength(255)]
        public string icon {  get; set; }
        [StringLength(255)]
        public string seotitle { get; set; }
        [StringLength(255)]
        public string seodescription { get; set; }
        [StringLength(255)]
        public string seokeywwords { get; set; }
        [StringLength(255)]
        public string alias { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}