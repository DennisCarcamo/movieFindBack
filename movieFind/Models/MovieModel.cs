using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieFind.Models
{
    public class MovieModel
    {
        [Key]
        public int id_movie { get; set; }
        public string  name_movie { get; set; }
        public string description { get; set; }
        public int id_type { get; set; }
    }
}
