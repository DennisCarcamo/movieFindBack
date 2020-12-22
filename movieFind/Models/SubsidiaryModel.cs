using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieFind.Models
{
    public class SubsidiaryModel
    {
        [Key]
        public int id_subsidiary { get; set; }
        public int id_department { get; set; }
        public string name_subsidiary { get; set; }
        public string address { get; set; }
    }
}
