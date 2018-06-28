﻿using System;
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

        public ActionResult Index(int? volLimit = null)
        {
            if (volLimit == null)
            {
                return View(service.GetAll());
            }
            return View(service.GetVolumeLargerThan(volLimit.Value));
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
            box.CreatedAt = DateTime.Now;
                service.AddBox(box);
                return View("Index", service.GetAll());
        }

        public ActionResult Edit(int id)
        {
            BoxInventory box = service.GetById(id);
            return View(box);
        }

        [HttpPost]
        public ActionResult Edit(BoxInventory box, int IdTP)
        {
                box.Id = IdTP;
                service.EditBox(box);
                return View("Details", box);
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

        [HttpPost]
        public ActionResult Search(int volLimit)
        {
            return RedirectToAction("Index", new { volLimit = volLimit });
        }
    }
}