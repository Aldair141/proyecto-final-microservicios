using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.SECURITY.Models
{
    public class Usuarios
    {
        [Key]
        public int id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}