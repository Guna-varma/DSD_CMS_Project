using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.Model.Models
{
    public class ApplicationImages
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("App Image Types")]
        public string AppImageTypes { get; set; }

        [Required]
        [DisplayName("Asset Title")]
        public string AssetTitle { get; set;}

        [Required]
        [DisplayName("Upload Asset")]
        [ValidateNever]
        [MaxLength(20 * 1024 * 1024, ErrorMessage = "The file size should not exceed 20MB.")]
        public string UploadAsset { get; set;}

        [Required]
        [DisplayName("Upload Thumb Image")]
        [ValidateNever]
        [MaxLength(20 * 1024 * 1024, ErrorMessage = "The file size should not exceed 20MB.")]
        public string UploadThumbImage { get; set;}
    }
}
