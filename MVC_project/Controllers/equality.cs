using MVC_project.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_project.Controllers
{
    public class equality : IEqualityComparer<Attendance>
    {
        

       
        public bool Equals(Attendance x, Attendance y)
        {
           
            return x.st_id == y.st_id && x.attend_date == y.attend_date
                
                &&x.attend_time==y.attend_time;

        }

        
        public int GetHashCode(Attendance obj)
        {
            return 1;
        }
    }
}