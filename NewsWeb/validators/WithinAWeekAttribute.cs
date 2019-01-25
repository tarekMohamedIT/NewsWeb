using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsWeb.validators
{
    public class WithinAWeekAttribute : RangeAttribute
    {
        public WithinAWeekAttribute()
    : base(typeof(DateTime), 
            DateTime.Now.ToShortDateString(),
            DateTime.Now.AddDays(7).ToShortDateString())
  { }
    }
}