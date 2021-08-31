using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_project.Models
{
    public class Attendance
    {
        [Key]
            
        [ForeignKey("ApplicationUser")]
        [Column(Order =0)]
        public string st_id { get; set; }
        [Key]

        [Column(Order = 1, TypeName = "date")]
        
        //[DataType(DataType.Date)]
        public DateTime attend_date { get; set; }
        public string attend_time { get; set; }//////mohammed
        public string Exit_time { get; set; }//////mohammed
        public ApplicationUser ApplicationUser { get; set; }
        /*****************************************************************/

        [NotMapped]
        public int? abscents { get; set; }

        [NotMapped]
        public int? attends { get; set; }
        [NotMapped]
        public int? delay { get; set; }
        [NotMapped]
        public int? intime { get; set; }
        /*****************************************************************/

    }
}