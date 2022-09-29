using AutoMapper;
using Cargo4You.Contracts;
using Cargo4You.DTO;
using Cargo4You.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cargo4You.Controllers
{
    public class CalculationController : Controller
    {
        private readonly ICargo4YouBLL _bll;
        private readonly IMapper _mapper;

        public CalculationController(ICargo4YouBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new CalculationViewModel();
            
            return View(model);
        }
        [HttpPost]
        public ActionResult CalculatePrices(CalculationViewModel model)
        {
            
                var calculationDTO = _mapper.Map<CalculationDTO>(model);
                var finalPricesDTO = _bll.CalculatePricesBasedOnUserInput(calculationDTO);
                model.CalculatedCouriesPrices = _mapper.Map<List<CalculatedCourierPriceViewModel>>(finalPricesDTO);

                return PartialView("_CalculateCourierPrices", model);
        }
    }
}
