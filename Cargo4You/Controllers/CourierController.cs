using AutoMapper;
using Cargo4You.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cargo4You.Controllers
{
    public class CourierController : Controller
    {
        private readonly ICargo4YouBLL _bll;
        private readonly IMapper _mapper;

        public CourierController(ICargo4YouBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var courires = _bll.GetCouriers();
            return View(courires);
        }

        
    }
}
