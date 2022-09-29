using System;
using System.Collections.Generic;
using System.Text;

namespace Cargo4You.DTO
{
   public class CalculationDTO
    {
        public CalculationDTO()
        {
            CalculatedCouriesPricesDTO = new List<CalculatedCourierPriceDTO>();
            UserInputDTO = new UserInputDTO();
        }
        public List<CalculatedCourierPriceDTO> CalculatedCouriesPricesDTO { get; set; }
        public UserInputDTO UserInputDTO { get; set; }
    }
}
