using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieFind.Models
{
    public class UserModel
    {
        [Key]
        public int id_user { get; set; }
        public int id_type { get; set; }
        public string name_user { get; set; }
        public string last_name_user { get; set; }
        public int id_doc_user { get; set; }
        public string email { get; set; }
        public string[] movie_genres { get; set; }
    }
}
