﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class BasketItem : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int BasketId { get; set; }

    }
}
