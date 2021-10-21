using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Models
{
    public class NewCategoryViewModel
    {
        [Required, MaxLength(100)]
        public string CategoryName { get; set; }
    }
}
