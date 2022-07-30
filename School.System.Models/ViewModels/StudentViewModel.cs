using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.System.ViewModels
{
    public class StudentViewModel
    {
        [Required]
        public int Id {get; set;}   
        
        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }


        [Required]
        [StringLength(50)]
        public string Email { get; set; }   

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public class StudentCreateViewModel
        {
            [Required]
            [StringLength(20)]
            public string Name { get; set; }

            [Required]
            [StringLength(50)]
            public string Email { get; set; }

            [StringLength(15)]
            public string? PhoneNumber { get; set; }

        }

    }
}
