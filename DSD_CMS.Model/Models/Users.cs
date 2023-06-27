using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSD_CMS.Model.Models
{
    public class Users
    {
        [Key]
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("User Name")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(30, ErrorMessage = "Password must be maximum 30 characters.")]
        [DisplayName("Password")]
        [RegularExpression(@"^[A-Za-z./@#$%^&*()\s]+$", ErrorMessage = "Only alphabets, dot, slash, @, #, $, %, ^, &, *, ( ), and spaces are allowed.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [MaxLength(30, ErrorMessage = "Confirm password must be maximum 30 characters.")]
        [DisplayName("Confirm Password")]
        [RegularExpression(@"^[A-Za-z./@#$%^&*()\s]+$", ErrorMessage = "Only alphabets, dot, slash, @, #, $, %, ^, &, *, ( ), and spaces are allowed.")]
        [Compare("Password", ErrorMessage = "The password and confirm password must match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("First Name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string FirstName { get; set; }


        [MaxLength(30)]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(14)]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [MaxLength(10, ErrorMessage = "Mobile number must be maximum 10 digits.")]
        [DisplayName("Mobile")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers are allowed.")]
        public string Mobile { get; set; }

        [MaxLength(11, ErrorMessage = "Land Line must be maximum 11 digits.")]
        [DisplayName("Land Line")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers are allowed.")]
        public string LandLine { get; set; }

        [DisplayName("Address Line1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line2")]
        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [DisplayName("City")]
        [StringLength(50)]
        public string City { get; set; }

        [DisplayName("State")]
        [StringLength(50)]
        public string State { get; set; }

        [DisplayName("Country")]
        [StringLength(50)]
        public string Country { get; set; }

        [DisplayName("User Role")]
        [StringLength(50)]
        [Required(ErrorMessage ="User Role is Required")]
        public string UserRole { get; set; }

    }
}
