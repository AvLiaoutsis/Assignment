using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Repository.IRepository;

namespace CiteAssignment.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class AttributeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttributeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowAll()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var AllObj = _unitOfWork.Company.GetAll();
            return Json(new { data = AllObj });
        }
    }
}