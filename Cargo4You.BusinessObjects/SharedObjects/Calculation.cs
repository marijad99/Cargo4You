using System;
using System.Collections.Generic;

#nullable disable

namespace Cargo4You.BusinessObjects.SharedObjects
{
    public partial class Calculation
    {
        public int Id { get; set; }
        public string FirstValue { get; set; }
        public string SecondValue { get; set; }
        public string Operator { get; set; }
        public int Price { get; set; }
        public int? ValidationId { get; set; }
        public bool? AdditionalCharges { get; set; }
        public int? AdditionalPrice { get; set; }
        public int? OverLimit { get; set; }

        public virtual Validation Validation { get; set; }
    }
}
