using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.Model.Models
{
    public class Settings
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Property Name")]
        public string PropertyName { get; set; }

        [Required]
        [DisplayName("Property Value")]
        public string PropertyValue { get; set; }
    }
}
