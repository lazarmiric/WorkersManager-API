using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public abstract class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //[Required]
        //public int SocialNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public City City { get; set; }

        [ForeignKey("City")]
        public int CityID { get; set; }
        //public string Adress { get; set; }
        //[Required]
        //public string UserType { get; set; }
        //public DateTime EmploymentDate { get; set; }

    }
}
