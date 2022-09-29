using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cargo4You.Exceptions
{
    public abstract partial class ExceptionCodes
    {
        /// <suErrorary>
        /// Enum ExceptionCodes for user defined error codes
        /// </suErrorary>
        public enum BaseExceptions
        {
            [Description("An unknown error occured")]
            unhandled_exception
        }

        public enum BLLExceptions
        {
            GetAllCourierListError,
            CalculatePriceError,
            GetPriceError,
            CalculatePricesBasedOnUserInputError,
            CheckValidationError,
            CheckValidationRulesError

        }
    }
}
