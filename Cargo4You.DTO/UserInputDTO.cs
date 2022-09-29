using System;
using System.Collections.Generic;
using System.Text;

namespace Cargo4You.DTO
{
   public class UserInputDTO
    {
        public UserInputDTO()
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
