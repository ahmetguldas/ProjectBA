using System;

namespace ApplicationCore.Entities
{
   public class Contact :BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
