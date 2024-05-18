using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cake_shop.Models
{
    public class NewsAndPostViewModel
    {
        public List<NewsModel> News { get; set; }
        public List<Post> Posts { get; set; }
    }
}