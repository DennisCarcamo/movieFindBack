using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieFind.Models
{
    public class FunctionModel
    {
        [Key]
        public int id_function { get; set; }
        public int id_room { get; set; }
        public int id_movie { get; set; }
        public DateTime func_time { get; set; }

    }
}
