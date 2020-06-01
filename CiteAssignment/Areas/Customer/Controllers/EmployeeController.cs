using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Repository.IRepository;
using Project.Models;

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

        public IActionResult Upsert(int? id)
        {
            var employee = new Employee();

            if (id == null)
            {
                //this is for create
                return View(employee);
            }

            // this is for edit
            employee = _unitOfWork.Employee.Get(id.GetValueOrDefault());

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var AllObj = _unitOfWork.Employee.GetAll();
            return Json(new { data = AllObj });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(employee.EMP_ID))
                {
                    _unitOfWork.Employee.Add(employee);
                }
                else
                {
                    _unitOfWork.Employee.Update(employee);
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Employee.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Employee.Remove(objFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}