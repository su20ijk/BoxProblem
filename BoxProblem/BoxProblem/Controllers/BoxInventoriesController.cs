using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;
using Microsoft.AspNetCore.Mvc;

namespace BoxProblem.Controllers
{
    public class BoxInventoriesController : Controller
    {
        private BoxInventoryService service;

        public BoxInventoriesController(ApplicationDbContext context)
        {
            service = new BoxInventoryService(context);
        }

        public IActionResult Index()
        {
            return View(service.GetAllBoxes());
        }

        public ActionResult Detail(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.AddBoxInventory(box);
                return RedirectToAction("Index");
            }

            return View(box);
        }

        public ActionResult Edit(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.SaveEdits(box);
                return RedirectToAction("Detail");
            }

            return View(box);
        }

        public ActionResult Delete(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            return View(box);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoxInventory box = service.GetBoxById(id);
            service.DeleteBox(box);
            return RedirectToAction("Index");
        }
    }
}