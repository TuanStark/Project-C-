using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cake_shop.Models.EF
{
    [Table("galery")]
    public class GaleryModels : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long Products_id { get; set; }

        [StringLength(255)]
        public string thumbnail { get; set; }
        public bool isDefault { get; set; }

        [ForeignKey("Products_id")]
        public virtual ProductModel Products { get; set; }

    }
}
