using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Employee : User
    {
        [Required]
        public int SocialNumber { get; set; }

        public DateTime EmploymentDate { get; set; }
    }
}
