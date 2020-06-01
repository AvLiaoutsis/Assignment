using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Repository.IRepository;
using Project.Models;
using Project.Models.ViewModels;

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
            var viewModel = new EmployeeAttrViewModel()
            {
                Employee = new Employee(),
                Attributes = _unitOfWork.Attribute.GetAll().ToList()
            };

            if (id == null)
            {
                //this is for create
                return View(viewModel);
            }

            // this is for edit
            viewModel.Employee = _unitOfWork.Employee.Get(id.GetValueOrDefault());

            if (viewModel.Employee == null)
            {
                return NotFound();
            }

            return View(viewModel);
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
        public IActionResult Upsert(EmployeeAttrViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Employee.EMP_ID == Guid.Empty)
                {
                    _unitOfWork.Employee.Add(viewModel.Employee);
                }
                else
                {
                    _unitOfWork.Employee.Update(viewModel.Employee);
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                viewModel.Attributes = _unitOfWork.Attribute.GetAll().ToList();


                if (viewModel.Employee.EMP_ID == Guid.Empty)
                {
                    viewModel.Employee = _unitOfWork.Employee.Get(viewModel.Employee.EMP_ID);
                }
            }
            return View(viewModel);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
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