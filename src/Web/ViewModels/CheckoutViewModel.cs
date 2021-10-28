using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class CheckoutViewModel
    {
        public decimal TotalPrice() => BasketItems.Sum(x => x.Price * x.Quantity);

        public List<BasketItemViewModel> BasketItems { get; set; }

        [Required, MaxLength(180)]
        public string Street { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [MaxLength(60)]
        public string State { get; set; }

        [Required, MaxLength(90)]
        public string Country { get; set; }

        [Required, MaxLength(18)]
        public string ZipCode { get; set; }

        public string CCHolderName { get; set; }
        public string CCNumber { get; set; }
        public string CCExpiration { get; set; }
        public string CCCvv { get; set; }
    }
}
