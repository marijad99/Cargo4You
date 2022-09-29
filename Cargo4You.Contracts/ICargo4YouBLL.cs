using System;
using System.Collections.Generic;
using System.Text;
using Cargo4You.BusinessObjects.SharedObjects;
using Cargo4You.DTO;

namespace Cargo4You.Contracts
{
   public interface ICargo4YouBLL
    {
        public List<Courier> GetCouriers();
        public List<CalculatedCourierPriceDTO> CalculatePricesBasedOnUserInput(CalculationDTO calculationDTO);
    }
}
