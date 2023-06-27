using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.Model.Models
{
    public class Dealers
    {
        [Key]
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Dealer Name")]
        public string DealerName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Dealer Location")]
        public string DealerLocation { get; set; }

        [DisplayName("Contact No")]
        [StringLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only NUMBERS are allowed.")]
        public string ContactNo { get; set;}

        [DisplayName("Address Line1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line2")]
        [StringLength(100)]
        public string AddressLine2 { get; set;}

        [DisplayName("City")]
        [StringLength(50)]
        public string City { get; set;}

        [DisplayName("State")]
        [StringLength(50)]
        public string State { get; set;}

        [DisplayName("Country")]
        [StringLength(50)]
        public string Country { get; set;}

    }
}
