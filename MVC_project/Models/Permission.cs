using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_project.Models
{
    public class Permission
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Permission_ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string st_ID { get; set; }
        [Column(TypeName ="date")]
      //  [Required(ErrorMessage ="must be enter")]
        public DateTime date { get; set; }
        public string Reason { get; set; }
        
        public bool Acceptance { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}