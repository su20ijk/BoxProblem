using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.Data;
using BoxProblem.Server;
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
            return View(service.GetAll());
        }

        public ActionResult Details(int id)
        {
            BoxInventory boxDetail = service.GetById(id);
            return View(boxDetail);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BoxInventory box)
        {
                service.AddBox(box);
                return RedirectToAction("Index", service.GetAll());
        }

        public ActionResult Edit(int id)
        {
            BoxInventory box = service.GetById(id);
            return View(box);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoxInventory box)
        {
            if (ModelState.IsValid)
            {
                service.EditBox(box);
                return RedirectToAction("Detail");
            }

            return View(box);
        }

        public ActionResult Delete(int id)
        {
            BoxInventory box = service.GetById(id);
            return View(box);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoxInventory box = service.GetById(id);
            service.DeleteBox(box);
            return RedirectToAction("Index");
        }
    }
}