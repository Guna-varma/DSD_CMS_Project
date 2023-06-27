using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DSD_CMS.Model.Models
{
    public class Extras
    {
        [Key]
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Extra Categories")]
        public string ExtraCategories { get; set; }

        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }


        [Required]
        [DisplayName("Thumb")]
        [ValidateNever]
        [MaxLength(20 * 1024 * 1024, ErrorMessage = "The file size should not exceed 20MB.")]
        public string Thumb { get; set; }

        [Required]
        [DisplayName("Asset")]
        [ValidateNever]
        [MaxLength(20 * 1024 * 1024, ErrorMessage = "The file size should not exceed 20MB.")]
        public string Asset { get; set; }

    }
}
