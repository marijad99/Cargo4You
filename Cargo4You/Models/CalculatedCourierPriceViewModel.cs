using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cargo4You.Models
{
    public class CalculatedCourierPriceViewModel
    {
        public CalculatedCourierPriceViewModel()
        {

        }
        public int Id { get; set; }
        public int Price { get; set; }
        public string CourierName { get; set; }
    }
}
