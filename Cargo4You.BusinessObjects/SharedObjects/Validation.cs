using System;
using System.Collections.Generic;


namespace Cargo4You.BusinessObjects.SharedObjects
{
    public partial class Validation
    {
        public Validation()
        {
            Calculations = new HashSet<Calculation>();
        }

        public int Id { get; set; }
        public string FirstValue { get; set; }
        public string SecondValue { get; set; }
        public string Unit { get; set; }
        public string Operator { get; set; }
        public int CourierId { get; set; }

        public virtual Courier Courier { get; set; }
        public virtual ICollection<Calculation> Calculations { get; set; }
    }
}
