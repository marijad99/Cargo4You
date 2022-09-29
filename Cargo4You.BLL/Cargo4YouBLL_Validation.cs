using Cargo4You.BusinessObjects.SharedObjects;
using Cargo4You.Contracts;
using Cargo4You.Core;
using Cargo4You.Core.Exceptions;
using Cargo4You.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Cargo4You.Core.Enums;

namespace Cargo4You.BLL
{
    public partial class Cargo4YouBLL : ICargo4YouBLL
    {
        public List<Validation> CheckValidationRules(int weight, int cubic)
        {
            try
            {
                var validValidationRulesId = new List<int>();
                var validationRules = _validationRepo.GetAsQueryable()
                                                        .Include(x => x.Calculations)
                                                        .Include(x=>x.Courier);
                foreach (var vr in validationRules)
                {
                    if(vr.Unit == ((int)Enums.Unit.Kg).ToString())
                        CheckValidation(vr, weight, validValidationRulesId);
                    else if(vr.Unit == ((int)Enums.Unit.Cm3).ToString())
                        CheckValidation(vr, cubic, validValidationRulesId);
                }
                if (validationRules != null)
                    return validationRules.Where(x => validValidationRulesId.Any(z => x.Id == z)).ToList();
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw new BLLException(ExceptionCodes.BLLExceptions.CheckValidationRulesError, "Error ocured while checking the validations");
            }
        }
     

        #region private
        private void CheckValidation(Validation validation, int userInputValue, List<int> validValidationRulesIds)
            {
            try
            {
                switch (Int32.Parse(validation.Operator))
                {
                    case (int)Operators.BetweenGreaterThan:
                        if(validation.FirstValue!= null && validation.SecondValue != null)
                        {
                            if (Int32.Parse(validation.FirstValue) < userInputValue && userInputValue <= Int32.Parse(validation.SecondValue))
                            validValidationRulesIds.Add(validation.Id);
                        }
                        break;
                    case (int)Operators.GreaterThanOrEqual:
                        if (validation.FirstValue != null)
                        {
                            if (userInputValue >= Int32.Parse(validation.FirstValue))
                            validValidationRulesIds.Add(validation.Id);
                        }
                        break;
                    case (int)Operators.LessThanOrEqual:
                        if (validation.FirstValue != null)
                        {
                            if (userInputValue <= Int32.Parse(validation.FirstValue))
                            validValidationRulesIds.Add(validation.Id);
                        }
                        break;
                    case (int)Operators.Equal:
                        if (validation.FirstValue != null)
                        {
                            if (Int32.Parse(validation.FirstValue) == userInputValue)
                            validValidationRulesIds.Add(validation.Id);
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                throw new BLLException(ExceptionCodes.BLLExceptions.CheckValidationError, "Error ocured while checking the validations");
            }
        }
        
        #endregion
    }

}

