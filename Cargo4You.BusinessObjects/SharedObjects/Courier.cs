using System;
using System.Collections.Generic;

#nullable disable

namespace Cargo4You.BusinessObjects.SharedObjects
{
    public partial class Courier
    {
        public Courier()
        {
            Validations = new HashSet<Validation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Validation> Validations { get; set; }
    }
}
