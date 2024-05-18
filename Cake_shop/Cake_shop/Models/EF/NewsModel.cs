using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Models.EF
{
    [Table("news")]
    public class NewsModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(255)]
        public string title { get; set; }
        [AllowHtml]
        public string content { get; set; }

        [StringLength(255)]
        public string sumary { get; set; }

        [StringLength(255)]
        public string img { get; set; }
        public string alias { get; set; }
    }
}