using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.Model.Models
{
    public class InteractiveChecksheets
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Category")]
        public string Category { get; set; }

        [Required]
        [DisplayName("Model Code")]
        [RegularExpression(@"^[A-Z a-z 0-9 . ' ( ) / -]+$", ErrorMessage = "Invalid characters are Detected!")]
        public string Question { get; set; }

    }
}
