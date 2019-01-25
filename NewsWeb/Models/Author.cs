using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsWeb.Models
{
    public class Author
    {
        public int AuthorID { get; set; }

        [Required]
        [RegularExpression("\\w{2, 20}", ErrorMessage = "This field is in incorrect format")]
        public string Name { get; set; }
    }
}