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

        public static string getDifference(DateTime date)
        {
            if (date.Year < DateTime.Now.Year)
                return (date.Year - DateTime.Now.Year) + " years ago";

            if (date.Month < DateTime.Now.Month)
                return (date.Month - DateTime.Now.Month) + " months ago";

            if (date.Day < DateTime.Now.Day)
                return (date.Day - DateTime.Now.Day) + " days ago";

            return "New";
        }
    }
}