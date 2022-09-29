using Cargo4You.BusinessObjects.SharedObjects;
using Cargo4You.Contracts;
using Cargo4You.Core.Exceptions;
using Cargo4You.DTO;
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
        
        public List<CalculatedCourierPriceDTO> CalculatePricesBasedOnUserInput(CalculationDTO calculationDTO)
        {
            List<CalculatedCourierPriceDTO> finalPricesDTO = new List<CalculatedCourierPriceDTO>();
            try
            {
                var cubicCentimetre = CalculateCubicCentimetre(calculationDTO.UserInputDTO);
                var weight = calculationDTO.UserInputDTO.Weight;
                var validValidationRules = CheckValidationRules(weight, cubicCentimetre);
                if (validValidationRules != null && validValidationRules.Count > 0)
                    CaluclatePrice(validValidationRules, weight, cubicCentimetre, finalPricesDTO);
            }
            catch(Exception ex)
            {
                throw new BLLException(ExceptionCodes.BLLExceptions.CalculatePricesBasedOnUserInputError, "Error ocured while calculating the prices");
            }
            return finalPricesDTO;
        }

        public void CaluclatePrice(List<Validation> validations, int weight, int cubic, List<CalculatedCourierPriceDTO> finalPricesDTO )
        {

            try
            {
                var priceWeight = 0;
                var maxCubic = 0;
                var maxWeight = 0;
                var priceCubic = 0;

                foreach (var va in validations)
                {
                    priceCubic = 0;
                    priceWeight = 0;
                    maxCubic = 0;
                    maxWeight = 0;
                    foreach (var cal in va.Calculations)
                    {
                        if (va.Unit == ((int)Unit.Kg).ToString())
                        {
                            priceWeight = GetPrice(cal, weight);
                            if (priceWeight > maxWeight)
                                maxWeight = priceWeight;
                        }
                            
                        else if (va.Unit == ((int)Unit.Cm3).ToString())
                        {
                            priceCubic = GetPrice(cal, cubic);
                            if (priceCubic > maxCubic)
                                maxCubic = priceCubic;
                        }
                           
                    }
                    if (maxCubic != 0 || maxWeight != 0)
                    {
                        if (finalPricesDTO.Any(x => x.Id == va.CourierId))
                        {
                            finalPricesDTO.FirstOrDefault(x => x.Id == va.CourierId).Price = maxCubic > maxWeight ? maxCubic : maxWeight;
                        }
                        else
                        {
                            finalPricesDTO.Add(new CalculatedCourierPriceDTO
                            {
                                Id = va.CourierId,
                                CourierName = va.Courier.Name,
                                Price = maxCubic > maxWeight ? maxCubic : maxWeight
                            });
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                throw new BLLException(ExceptionCodes.BLLExceptions.CalculatePriceError, "Error ocured while calculating the prices");
            }
        }
        #region 
        private int CalculateCubicCentimetre(UserInputDTO userInputDTO)
        {
            if(userInputDTO.Depth != null && userInputDTO.Height != null && userInputDTO.Width != null)
                return userInputDTO.Depth * userInputDTO.Height * userInputDTO.Width;
            return 0;
        }

        private int GetPrice(Calculation calculationRule, int value)
        {
            var price = 0;
            try {
                switch (Int32.Parse(calculationRule.Operator))
                {
                    case (int)Operators.BetweenGreaterThan:
                        if (calculationRule.FirstValue != null && calculationRule.SecondValue != null)
                        {
                            if (Int32.Parse(calculationRule.FirstValue) < value && value <= Int32.Parse(calculationRule.SecondValue))
                                price = calculationRule.Price;

                        }
                        break;
                    case (int)Operators.GreaterThanOrEqual:
                        if (calculationRule.FirstValue != null)
                        {
                            if (value >= Int32.Parse(calculationRule.FirstValue))
                                price = calculationRule.Price;
                        }
                        break;
                    case (int)Operators.LessThanOrEqual:
                        if (calculationRule.FirstValue != null)
                        {
                            if (value <= Int32.Parse(calculationRule.FirstValue))
                                price = calculationRule.Price;
                        }
                        break;
                    case (int)Operators.Equal:
                        if (calculationRule.FirstValue != null)
                        {
                            if (Int32.Parse(calculationRule.FirstValue) == value)
                                price = calculationRule.Price;
                        }
                        break;
                    case (int)Operators.GreaterThan:
                        if (calculationRule.FirstValue != null)
                        {
                            if (value > Int32.Parse(calculationRule.FirstValue))
                                price = calculationRule.Price;
                        }
                        break;
                }
                if (calculationRule.AdditionalCharges != null && calculationRule.OverLimit.Value != null)
                    if (value > calculationRule.OverLimit.Value)
                        price += CalculateAdditionalCharges(calculationRule, value);
                return price;
            }
            catch(Exception ex)
            {
                throw new BLLException(ExceptionCodes.BLLExceptions.GetPriceError);
            }
            }
      

        private int CalculateAdditionalCharges(Calculation calculation, int value)
        {
            return (value - calculation.OverLimit.Value) * calculation.AdditionalPrice.Value;
        }
        #endregion
    }
}
