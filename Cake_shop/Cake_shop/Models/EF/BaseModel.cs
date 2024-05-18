using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cake_shop.Models
{
    public class BaseModel
    {
        public DateTime? createDate { set; get; }
        public DateTime? modifiedDate { set; get; }
        public string createBy { set; get; }
        public string modifiledBy { set; get; }

    }
}