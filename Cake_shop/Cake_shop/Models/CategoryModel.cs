using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cake_shop.Models.Admin
{
    [Table("category")]
    public class CategoryModel : BaseModel
    {
        public CategoryModel()
        {
            this.Produtcs = new HashSet<ProductModel>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string img {  get; set; }

        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        [StringLength(255)]
        public string name { get; set; }

        public string alias { get; set; }

        public ICollection<ProductModel> Produtcs { get; set; }
    }
}