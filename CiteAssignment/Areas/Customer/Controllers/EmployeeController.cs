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

    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(Guid id)
        {
            var employee = new EmployeeSpecial();

            if (id == Guid.Empty)
            {
                //this is for create
                employee.BirthDate = DateTime.Now.AddYears(-18);
                return View(employee);
            }

            // this is for edit
            employee = _unitOfWork.EmployeeSpecial.Get(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult ChangeAttributes(Guid id)
        {
            var employee = _unitOfWork.EmployeeSpecial.Get(id);

            var allAttributes = _unitOfWork.Attribute.GetAll().ToList();

            var chosenAttributes = _unitOfWork.EmployeeSpecialAttribute.GetAll(includeProperties:"Attribute").Select(u=>u.Attribute).ToList();

            var attributes = new AttributesViewModel()
            {
                AllAttributes = allAttributes,
                MyAttributes = chosenAttributes,
                Employee = employee
            };

            return View(attributes);

        }

        [HttpPost]
        public IActionResult ChangeAttributes ([FromBody] RandomViewModel viewModel)
        {

            var previousattributes = _unitOfWork.EmployeeSpecialAttribute.GetAll()
                .Where(u => u.EmployeeId == viewModel.EmployeeId);

            _unitOfWork.EmployeeSpecialAttribute.RemoveRange(previousattributes);

           
            foreach (var attributeid in viewModel.AttributeIds)
            {
                if (!string.IsNullOrWhiteSpace(attributeid))
                {
                    var newRelation = new EmployeeSpecialAttribute()
                    {
                        AttributeId = new Guid(attributeid),
                        EmployeeId = viewModel.EmployeeId
                    };
                    _unitOfWork.EmployeeSpecialAttribute.Add(newRelation);

                }

            }

            _unitOfWork.Save();

            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var AllObj = _unitOfWork.EmployeeSpecial.GetAll().ToList();
            return Json(new { data = AllObj });
        }

        [HttpGet]
        public IActionResult GetAllByAttribute(Attribute attribute)
        {
            var AllObj = _unitOfWork.EmployeeAttribute.GetAll(includeProperties: "Employee,Attribute").ToList();

            var result = AllObj.Where(u => u.EMPATTR_AttributeID == attribute.ATTR_ID);


            return Json(new { data = result });
        }

        [HttpGet]
        public IActionResult GetAllByAttributes(List<Attribute> attributes)
        {
            var AllObj = _unitOfWork.EmployeeAttribute.GetAll(includeProperties: "Employee,Attribute").ToList();

            var result = new List<EmployeeAttribute>();

             
            foreach (var attribute in attributes)
            {
                foreach (var person in AllObj)
                {
                    if(person.Attribute.Equals(attribute))

                    result.Add(new EmployeeAttribute()
                    {
                        Attribute = attribute,
                        Employee = person.Employee
                    });   
                }
            }
            return Json(new { data = result });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert( EmployeeSpecial employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Id == Guid.Empty)
                {
                    _unitOfWork.EmployeeSpecial.Add(employee);
                }
                else
                {
                    _unitOfWork.EmployeeSpecial.Update(employee);
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            //else
            //{
            //    viewModel.Attributes = _unitOfWork.Attribute.GetAll().ToList();


            //    if (viewModel.Employee.Id == Guid.Empty)
            //    {
            //        viewModel.Employee = _unitOfWork.EmployeeSpecial.Get(viewModel.Employee.Id);
            //    }
            //}
            return View(employee);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var objFromDb = _unitOfWork.EmployeeSpecial.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.EmployeeSpecial.Delete(id);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}