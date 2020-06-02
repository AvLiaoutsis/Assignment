using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Repository.IRepository;
using Attribute = Project.Models.Attribute;

namespace CiteAssignment.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class MapController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MapController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {


                return View();
        }

        [HttpPost]
        public IActionResult GetEmployees(Attribute attribute)
        {
            //Get List of Employee upon selected attribute
            var AllObj = _unitOfWork.EmployeeAttribute.GetAll(includeProperties: "Employee,Attribute").ToList();

            var result = AllObj.Where(u => u.EMPATTR_AttributeID == attribute.ATTR_ID).Select(u=>u.Employee);


            return Json(new { data = result });
        }








    }
}