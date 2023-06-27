using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.Model.Models
{
    public class Variant
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Invalid characters are Detected!")]
        public string VariantName { get; set; }

        [Required]
        public int CarModelId { get; set; }

        [ForeignKey("CarModelId")]
        [ValidateNever]
        public CarModel CarModel { get; set; }
    }
}
