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
    public class CarModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Model Name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string ModelName { get; set; }
        
        [Required]
        [DisplayName("Model Code")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Invalid characters are Detected!")]
        public string ModelCode { get; set; }

        [ValidateNever]
        [Required(ErrorMessage = "Car Image is Required")]
        [DisplayName("Car Image")]
        [MaxLength(1 * 1024 * 1024, ErrorMessage = "The file size should not exceed 1MB.")]
        public string CarImage { get; set; }

        [ValidateNever]
        [DisplayName("Front Angle Image")]
        [MaxLength(1 * 1024 * 1024, ErrorMessage = "The file size should not exceed 1MB.")]
        public string FrontAngleImage { get; set; }

        [ValidateNever]
        [DisplayName("Back Angle Image")]
        [MaxLength(1 * 1024 * 1024, ErrorMessage = "The file size should not exceed 1MB.")]
        public string BackAngleImage { get; set; }

        [ValidateNever]
        [DisplayName("Left Angle Image")]
        [MaxLength(1 * 1024 * 1024, ErrorMessage = "The file size should not exceed 1MB.")]
        public string LeftAngleImage { get; set; }

        [ValidateNever]
        [MaxLength(1 * 1024 * 1024, ErrorMessage = "The file size should not exceed 1MB.")]
        [DisplayName("Right Angle Image")]
        public string RightAngleImage { get; set; }

        [ValidateNever]
        [MaxLength(1 * 1024 * 1024, ErrorMessage = "The file size should not exceed 1MB.")]
        [DisplayName("Front Angle Line Image")]
        public string FrontAngleLineImage { get; set;}

        [ValidateNever]
        [MaxLength(1 * 1024 * 1024, ErrorMessage = "The file size should not exceed 1MB.")]
        [DisplayName("Back Angle Line Image")]
        public string BackAngleLineImage { get; set; }

        [ValidateNever]
        [MaxLength(1 * 1024 * 1024, ErrorMessage = "The file size should not exceed 1MB.")]
        [DisplayName("Left Angle Line Image")]
        public string LeftAngleLineImage { get; set;}

        [ValidateNever]
        [MaxLength(1 * 1024 * 1024, ErrorMessage = "The file size should not exceed 1MB.")]
        [DisplayName("Right Angle Line Image")]
        public string RightAngleLineImage { get; set; }

    }

}
