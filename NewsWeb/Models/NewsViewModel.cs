using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsWeb.Models
{
    public class NewsViewModel
    {
        public News News { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}