using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cargo4You.Models
{
    public class CalculationViewModel
    {
        public CalculationViewModel()
        {
            CalculatedCouriesPrices = new List<CalculatedCourierPriceViewModel>();
            UserInput = new UserInputViewModel();
        }
        public List<CalculatedCourierPriceViewModel> CalculatedCouriesPrices { get; set; }
        public UserInputViewModel UserInput { get; set; }
    }
}
