using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cargo4You.Core
{
    public class Enums
    {
        public enum Unit
        {
            [Description("Kg")]
            Kg = 1,
            [Description("Cm3")]
            Cm3 = 2

        }
        public enum Operators
        {
            
            [Description(">")]
            GreaterThan = 1,
            [Description(">=")]
            GreaterThanOrEqual = 2,
            [Description("<")]
            LessThan = 3,
            [Description("<=")]
            LessThanOrEqual = 4,
            [Description("==")]
            Equal = 5,
            [Description("><=")]
            BetweenGreaterThan = 6,
            [Description("<<=")]
            BetweenLessThan = 7,
        }

    }
}
