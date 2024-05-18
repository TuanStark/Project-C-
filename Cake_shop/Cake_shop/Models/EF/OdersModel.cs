using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cake_shop.Models.EF
{
    [Table("orders")]
    public class OdersModel : BaseModel
    {
        public OdersModel()
        {
            this.ordersDetails = new HashSet<OrdersDetails>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long id { get; set; }
        [Required]
        public long Users_id { get; set; }
        [StringLength(255)]
        public string fullName { get; set; }
        [StringLength(50)]
        public string email { get; set; }
        [StringLength(12)]
        public string phone { get; set; }
        [StringLength(50)]
        public string address { get; set; }
        public int status { get; set; }
        [StringLength(255)]
        public string note { get; set; } // cái này tương tự code
        public DateTime order_date { get; set; }
        public float total_money { get; set; }
        public int payment_methods {  get; set; }

        [ForeignKey("Users_id")]
        public virtual UserModel Users { get; set; }
        public ICollection<OrdersDetails> ordersDetails { get; set; }
    }
}