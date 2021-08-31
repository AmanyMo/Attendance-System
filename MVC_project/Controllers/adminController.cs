using MVC_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_project.Controllers
{
    public class adminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
         public ActionResult getattendance()
        {
            ViewBag.departments = new SelectList(db.Departments.ToList(), "department_id", "department_Name");
            return View();
        }
        [HttpPost]
        public ActionResult postattendance(int departments , string date)
        {
            var std = db.Users.Where(e => e.Dep_No == departments).ToList();
            var x = db.Students_Attendance.Where(a => a.ApplicationUser.Dep_No == departments).Include(w=>w.ApplicationUser).ToList();
            List<Attendance> att = new List<Attendance>();
            List<ApplicationUser> abs = new List<ApplicationUser>();
            
              foreach (var m in x)
                {
                    if (m.attend_date.ToString("yyyy-MM-dd") == date)
                    {
                       att.Add(m);
                    }
                }

            foreach(var item in std)
            {
                if (x.Exists(a => a.st_id == item.Id)==false)
                {
                    abs.Add(item);

                }
              
            }

            ViewBag.abs = abs;
            return View(att);
        }
        public ActionResult getinterval()
        {
            ViewBag.departments = new SelectList(db.Departments.ToList(), "department_id", "department_Name");

            return View();
        }

        public ActionResult postinterval(string startdate, string enddate, int departments)
        {
            List<Attendance> st_att = new List<Attendance>();
            var interval = DateTime.Parse(enddate) - DateTime.Parse(startdate);
            int aymam=int.Parse(interval.ToString("dd"));
            var std = db.Users.Where(e => e.Dep_No == departments).ToList();
            var atten = db.Students_Attendance.Where(a => a.ApplicationUser.Dep_No == departments).Include(w => w.ApplicationUser).ToList();
            List<Attendance> att = new List<Attendance>();
            List<Attendance> att2 = new List<Attendance>();

            List<ApplicationUser> abs = new List<ApplicationUser>();
         
            foreach(var i in atten)
            {
                string date = i.attend_date.ToString("yyyy-MM-dd");
                if (DateTime.Parse(date)>= DateTime.Parse(startdate)&& DateTime.Parse(date) <= DateTime.Parse(enddate))
                {
                    if (att.Contains(i,new equality()) == false)
                    {
                        att.Add(i);

                    }
                }
            }
            var distinctItems = att.Distinct(new equality());

            for (int i=0;i< att.Count; i++)
            {
                int hodour = 0;
                int kiab = 0;
                int delay = 0;
                int intime = 0;
                for (int j = 0; j < att.Count; j++)
                {
                    if (att[i].st_id == att[j].st_id)
                    {
                        hodour++;
                    }

                    //if (DateTime.Parse(att[i].attend_time)> DateTime.Parse("18:00"))
                    //{
                    //    delay++;
                    //}else if (DateTime.Parse(att[i].attend_time) <= DateTime.Parse("18:00"))
                    //{
                    //    intime++;
                    //}


                }
                att[i].attends = hodour;
                kiab = aymam - hodour;
                //att[i].delay = delay;
                //att[i].intime = intime;
                att[i].abscents = kiab;
            }

            foreach (var item in std)
            {
                
          
                if (atten.Exists(a => a.st_id == item.Id) == false)
                {

                    item.abscents = aymam;
                    abs.Add(item);
                    
                }

            }
            ViewBag.absentstudents = abs;





            return View(att);
        }

    }
}