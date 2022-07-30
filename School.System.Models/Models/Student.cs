using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.System.Models
{
    public class Student
    {
        
        public int Id {get; set;}   
        
        [Required]
        [StringLength(20)]
        
        public string Name {get; set;}
        
        
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; } //phone number is optional here thus the question mark.

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
        
        public bool Isdeleted { get; set;} = false; // this is for soft and hard delete in the database.
        public bool IsDeleted { get; set; }
    }
}
