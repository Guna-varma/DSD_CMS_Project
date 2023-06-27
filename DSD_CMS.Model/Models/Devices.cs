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
    public class Devices
    {
        [Key]
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Device UDID")]
        public string DeviceUDID { get; set; }
        
        [Required]
        [DisplayName("Device Name")]
        [StringLength(50)]
        public string DeviceName { get; set; }

        [DisplayName("Device Description")]
        [StringLength(100)]
        public string DeviceDescription { get; set; }

        [Required]
        public int DealerId { get; set; }

        [ForeignKey("DealerId")]
        [ValidateNever]
        public Dealers Dealer { get; set; }

        [Required]
        public int ShowroomId { get; set; }

        [ForeignKey("ShowroomId")]
        [ValidateNever]
        public Showrooms Showroom { get; set; }

    }
}
