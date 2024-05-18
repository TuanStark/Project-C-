using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Cake_shop.Models.EF
{
    [Table("menu")]
    public class Menu : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id {  get; set; }
        public string name {  get; set; }

/*        public string description { get; set; }
        [StringLength(250)]
        public string TypeCode { get; set; }

        public string alias { get; set; }*/

        public string link {  get; set; } 
    }
}