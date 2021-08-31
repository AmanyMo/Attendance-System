using MVC_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_project.Controllers
{
    public class permissionController:Controller
    {
        ApplicationDbContext db = new ApplicationDbContext(); 
        public ActionResult create() {

            return View();
        }
        [HttpPost]
        public ActionResult create(Permission permission)
        {
            db.permissions.Add(permission);
            db.SaveChanges();

            return RedirectToAction("index", "Home");
        }
    }
}