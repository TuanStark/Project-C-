using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cake_shop.Models.EF
{
    [Table("orders_details")]
    public class OrdersDetails : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long id { get; set; }
        [Required]
        public long Oders_id {  get; set; }
        [Required]
        public long ProductId { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public double total_money { get; set; }
        public virtual OdersModel Oders { get; set; }
        public virtual ProductModel Product { get; set;}
    }
}