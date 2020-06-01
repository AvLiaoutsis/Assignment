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

        #region API CALLS


        public IActionResult Upsert(Guid id)
        {
            var attribute = new Attribute();

            if (id == null)
            {
                //this is for create
                return View(attribute);
            }

            // this is for edit
            attribute = _unitOfWork.Attribute.Get(id);

            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var AllObj = _unitOfWork.Attribute.GetAll();
            return Json(new { data = AllObj });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Attribute attribute)
        {
            if (ModelState.IsValid)
            {
                if (attribute.ATTR_ID == Guid.Empty)
                {
                    _unitOfWork.Attribute.Add(attribute);
                }
                else
                {
                    _unitOfWork.Attribute.Update(attribute);
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(attribute);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var objFromDb = _unitOfWork.Attribute.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Attribute.Remove(objFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });

        }
    #endregion
    


    }
}