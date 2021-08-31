using MVC_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace MVC_project.Controllers
{

    public class DepStuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public static List<ApplicationUser> attendance_list = new List<ApplicationUser>();
        public static List<ApplicationUser> Exit_list = new List<ApplicationUser>();
        // GET: DepStu
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult listDepartments()
        {

            List<Department> departments = db.Departments.ToList<Department>();
            return View(departments);
        }

        [HttpPost]
        public ActionResult listDepartments(int id)
        {
            List<ApplicationUser> students = new List<ApplicationUser>();

            attendance_list = db.Users.Where(a => (a.Dep_No == id)).ToList<ApplicationUser>();
            //ViewBag.students = new SelectList(students, "Id", "UserName");
            //foreach(var item in attendance_list)
            //{
            // if (Exit_list.Exists(b => b.Id == item.Id))
            // {
            //     attendance_list.RemoveAll((a) => a.Id == item.Id);
            // }
            //}
            ViewBag.attendance_list = attendance_list;
            return View("listStudents");
        }
        [HttpPost]
        public ActionResult AddToAttendance(string id)
        {

            ApplicationUser student = db.Users.FirstOrDefault(a => a.Id == id);

            //bt check elstudent da etsagel abl keda attendance wla la 3shn mytsgelsh mareteen attendance fl database
            //3shn lw rg3 ldepartments w d5al tani byload kolelstudents mn gdid 7ata eleta5do flexit list 
            //hena hmn3 mo2akatan eno ysagelo tani fldatabase bs hwa mfrud mytl3sh tani asln 


            if (Exit_list.Exists(a => a.Id == id) == false)
            {
                Exit_list.Add(student);
                String hourMinute = DateTime.Now.ToString("HH:mm");///////////////mohammed
                var New = new Attendance { st_id = id, attend_date = DateTime.Now, attend_time = hourMinute, Exit_time = null };///mohammed
                db.Students_Attendance.Add(New);
                db.SaveChanges();
                if (student != null)   //elstudent elselected ytshal abl mytb3t llview 3shn myt3rdsh tani"mthandela lw wwa2ef fl department marg3sh w da5al tani zai m2olna flcomment elfo2"
                {
                    attendance_list.RemoveAll((a) => a.Id == id);
                }
            }
            else
            {
                return PartialView("alert");
            }

            ViewBag.attendance_list = attendance_list;
            return View("listStudents");

        }





        //-----------------------------------------------------------------------------------------     
        //not used maybe modified later
        public ActionResult GetStudentsInDep(int? id)
        {
            //List<ApplicationUser> users = _userManager.Users.ToList<ApplicationUser>();
            List<ApplicationUser> students = new List<ApplicationUser>();
            //List<string> st_names=new List<string>();
            // foreach (var item in users)
            //{
            //if((await _userManager.IsInRoleAsync(item.Id, "student" )== true) ){
            students = db.Users.Where(a => a.Dep_No == id).ToList<ApplicationUser>();
            //students.Add(item);
            //ViewBag.students = new SelectList(students, "Id", "Username");
            //foreach (var item in students)
            //{
            //    st_names.Add(item.UserName);
            // }
            //ViewBag.names = st_names;
            //}
            //}

            return PartialView(students);
        }
        //-------------------------------------------------------------------------------------------
        public ActionResult Exitlist()
        {
            ViewBag.Exit_list = Exit_list;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateExitTime(string id)
        {
            var exit = db.Students_Attendance.FirstOrDefault(a => a.st_id == id);
            String hourMinute = DateTime.Now.ToString("HH:mm");
            exit.Exit_time = hourMinute;
            db.SaveChanges();

            if (exit != null)   //elstudent elselected ytshal abl mytb3t llview 3shn myt3rdsh tani
            {
                Exit_list.RemoveAll((a) => a.Id == id);
            }
            ViewBag.Exit_list = Exit_list;
            return View("Exitlist");
        }
    }
}