using Cargo4You.BusinessObjects.SharedObjects;
using Cargo4You.Contracts;
using Cargo4You.Core.Exceptions;
using Cargo4You.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cargo4You.BLL
{
    public partial class Cargo4YouBLL : ICargo4YouBLL
    {
        public List<Courier> GetCouriers()
        {
            List<Courier> couriers = new List<Courier>();
            try
            {
               couriers = _courierRepo.GetAsQueryable().ToList();
            }
            catch (Exception ex)
            {
             
               throw new BLLException(ExceptionCodes.BLLExceptions.GetAllCourierListError);
            }
            return couriers;
        }
    }
}
