using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieFind.Models
{
    public class UserSubsidiaryModel
    {
        public int id_subsidiary { get; set; }
        public int id_user { get; set; }
    }
}
