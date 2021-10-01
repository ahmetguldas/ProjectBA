﻿using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
   public class Order :BaseEntity
    {
        public string CustomerName { get; set; }
        public int Ammount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
      //  public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
