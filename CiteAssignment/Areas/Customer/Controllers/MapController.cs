using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Repository.IRepository;
using Project.Models;
using Project.Models.ViewModels;
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
            var attributes = _unitOfWork.Attribute.GetAll().ToList();


            return View(attributes);
        }

        //[HttpPost]
        //public IActionResult GetEmployeesUponAttribute( Guid id)
        //{
        //    //Get List of Employee upon selected attribute
        //    var AllEmployees = _unitOfWork.EmployeeSpecialAttribute.GetAll(includeProperties: "Employee,Attribute").ToList();

        //    var result = AllEmployees.Where(u => u.AttributeId == id).Select(u=>u.Employee);


        //    return Json(new { data = result });
        //}



        public IActionResult GetEmployeesUponAttribute(string id)
        {
            //Get List of Employee upon selected attribute
            var AllEmployees = _unitOfWork.EmployeeSpecialAttribute.GetAll(includeProperties: "Employee,Attribute").ToList();

            var result = AllEmployees.Where(u => u.AttributeId.ToString() == id).Select(u => u.Employee).ToList();


            return View("ChoosePerson", result);
        }

        //[HttpPost]
        //public IActionResult GetEmployeesUponAttribute(Guid id,)
        //{
        //    //Get List of Employee upon selected attribute
        //    var AllEmployees = _unitOfWork.EmployeeSpecialAttribute.GetAll(includeProperties: "Employee,Attribute").ToList();

        //    var result = AllEmployees.Where(u => u.AttributeId == id).Select(u => u.Employee).ToList();


        //    return RedirectToAction("ChoosePerson", result);
        //}


        //public IActionResult ChoosePerson(IEnumerable<EmployeeSpecial> employees)
        //{

        //    return View(employees);
        //}
        [HttpPost]
        public IActionResult GenerateMap([FromBody] EmployeesMapIdViewModel viewModel)
        {
            var selectedEmployee = _unitOfWork.EmployeeSpecial.Get(new Guid(viewModel.ChosenId));
            var otherEmployees = new List<EmployeeSpecial>();

            foreach (var id in viewModel.EmployeeIds)
            {
                otherEmployees.Add(_unitOfWork.EmployeeSpecial.Get(new Guid(id)));
            }

            var viewModelForMap = new EmployeesMapViewModel()
            {
                ChosenEmployee = selectedEmployee,
                OtherEmloyees = otherEmployees
            };

            return View("ShowMap", viewModelForMap);
        }

        //[HttpGet]
        //public IActionResult ShowMap()
        //{
        //    var viewModel = (EmployeesMapViewModel)TempData["map"];

        //    return View(viewModel);
        //}





    }
}