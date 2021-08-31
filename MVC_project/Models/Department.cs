using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVC_project.Models;

namespace MVC_project.Models
{
    public class Department
    {
        [Key]
        public int department_id { get; set; }

        
        

        public string department_Name { get; set; }

        //la properite de navigation
        public List<ApplicationUser> Students { get; set; }
    }
}