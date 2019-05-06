using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Phone]
        public string Number { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
    }
}
