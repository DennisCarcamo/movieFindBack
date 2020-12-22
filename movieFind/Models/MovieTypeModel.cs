using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieFind.Models
{
    public class MovieTypeModel
    {
        [Key]
        public int id_type { get; set; }
        public string genre { get; set; }
        public string description { get; set; }
    }
}
