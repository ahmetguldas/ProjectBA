using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   public class Author :BaseEntity
    {
        public string AuthorName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
