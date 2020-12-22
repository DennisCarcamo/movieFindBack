using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieFind.Models
{
    public class DepartmentModel
    {
        [Key]
        public int id_department { get; set; }
        public string name_department { get; set; }
    }
}
