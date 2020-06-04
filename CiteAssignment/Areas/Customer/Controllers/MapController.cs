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


        public IActionResult GetEmployeesUponAttribute(string id)
        {
            //Get List of Employee upon selected attribute
            var AllEmployees = _unitOfWork.EmployeeSpecialAttribute.GetAll(includeProperties: "Employee,Attribute").ToList();

            var result = AllEmployees.Where(u => u.AttributeId.ToString() == id).Select(u => u.Employee).ToList();

            var viewModel = new EmployeesMapIdViewModel()
            {
                AllEmployees = result,
            };

            return View("ChoosePerson", viewModel);
        }

        
        [HttpPost]
        public IActionResult GenerateMap( EmployeesMapIdViewModel viewModel)
        {
            var selectedEmployee = _unitOfWork.EmployeeSpecial.Get(new Guid(viewModel.ChosenId));
            var otherEmployees = new List<EmployeeSpecial>();

            foreach (var emp in viewModel.AllEmployees)
            {
                otherEmployees.Add(_unitOfWork.EmployeeSpecial.Get(emp.Id));
            }

            otherEmployees.Remove(selectedEmployee);

            var viewModelForMap = new EmployeesMapViewModel()
            {
                ChosenEmployee = selectedEmployee,
                OtherEmloyees = otherEmployees
            };

            return View("ShowMap", viewModelForMap);
        }


    }
}