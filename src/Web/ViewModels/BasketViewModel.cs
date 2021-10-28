using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemViewModel> Items { get; set; }

        public decimal TotalPrice()
        {
            return Items.Sum(x => x.Quantity * x.Price);
        }
    }
}
