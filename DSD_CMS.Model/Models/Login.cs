using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.Model.Models
{
    public class Login
    {
        [Required]
        [DisplayName("UserName")]
        public string userName { get;set; }


        [Required]
        [DisplayName("Password")]
        public string password { get;set; }
    }
}
