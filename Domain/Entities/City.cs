using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class City: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Ptt { get; set; }
       
    }
}
