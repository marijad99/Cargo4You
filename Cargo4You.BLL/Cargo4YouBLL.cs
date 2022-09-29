using Cargo4You.BusinessObjects.SharedObjects;
using Cargo4You.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cargo4You.BLL
{
    public partial class Cargo4YouBLL : ICargo4YouBLL
    {
        IUnitOfWork<Cargo4YouContext> _uow { get; set; }
        IGenericRepository<Courier> _courierRepo { get; set; }
        IGenericRepository<Validation> _validationRepo { get; set; }
        IGenericRepository<Calculation> _calculationRepo { get; set; }

        private readonly AutoMapper.IMapper _mapper;


        public Cargo4YouBLL(IUnitOfWork<Cargo4YouContext> uow, AutoMapper.IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _courierRepo = _uow.GetGenericRepository<Courier>();
            _validationRepo = _uow.GetGenericRepository<Validation>();
            _calculationRepo = _uow.GetGenericRepository<Calculation>();
        }
    }
}
