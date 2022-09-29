using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cargo4You.Models
{
    public class UserInputViewModel
    {
        public UserInputViewModel()
        {

        }
        public int UserId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public int ChosenCourier { get; set; }
    }
}
