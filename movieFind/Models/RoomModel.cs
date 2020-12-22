using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieFind.Models
{
    public class RoomModel
    {
        [Key]
        public int id_room { get; set; }
        public int id_subsidiary { get; set; }
        public string name_room { get; set; }
    }
}
