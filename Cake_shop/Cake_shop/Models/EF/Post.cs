using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Models.EF
{
    [Table("post")]
    public class Post : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        [StringLength(255)]
        public string title { get; set; }
        [StringLength(255)]
        public string description { get; set; }
        [StringLength(255)]
        public string alias { get; set; }
        [AllowHtml]
        public string detail { get; set; }
        [StringLength(255)]
        public string image { get; set; }
    }
}