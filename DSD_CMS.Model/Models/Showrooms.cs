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
    public class Showrooms
    {
        [Key]
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Showroom Name")]
        public string ShowroomName { get; set; }
        
        [Required]
        [DisplayName("Showroom Location")]
        public string ShowroomLocation { get; set; }

        [DisplayName("Contact No")]
        [StringLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only NUMBERS are allowed.")]
        public string ContactNo { get; set; }

        [DisplayName("Fax No")]
        [StringLength(7)]
        public string FaxNo { get; set; }

        [DisplayName("Devices")]
        public string Devices { get; set;}

        [DisplayName("Email")]
        [RegularExpression(@"^[A-Za-z0-9.@'()/-]+$", ErrorMessage = "Invalid characters are detected!")]
        [StringLength(100, ErrorMessage = "Email address cannot exceed 100 characters.")]
        public string Email { get; set; }

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

        [DisplayName("Region")]
        [StringLength(50)]
        public string Region { get; set; }

        [Required]
        public int DealerId { get; set; }

        [ForeignKey("DealerId")]
        [ValidateNever]
        [DisplayName("Dealer Name")]
        public Dealers DealerName { get; set; }

    }
}
