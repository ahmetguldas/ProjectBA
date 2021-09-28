﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   public class Review :BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
