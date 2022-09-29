using System;
using System.Collections.Generic;
using System.Text;

namespace Cargo4You.DTO
{
   public class CalculatedCourierPriceDTO
    {
        public CalculatedCourierPriceDTO()
        {

        }
        public int Id { get; set; }
        public int Price { get; set; }
        public string CourierName { get; set; }
    }
}
