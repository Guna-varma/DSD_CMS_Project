using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.Model.Models
{
    public class HealthCard
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("SR#")]
        public String Sr { get; set; }

        [Required]
        [DisplayName("Customer")]
        public String Customer { get; set; }
        
        [Required]
        [DisplayName("Mileage")]
        public double Mileage { get; set; } = 0;

        [Required]
        [DisplayName("Tread Depth")]
        public string TreadDepth { get; set; }
        
        [Required]
        [DisplayName("Break pad")]
        public string Breakpad { get; set; }
        
        [Required]
        [DisplayName("Break Disc")]
        public string BreakDisc { get; set; }

        [Required]
        [DisplayName("Battery(Volts)")]
        public double Battery { get; set; } = 0;
    }
}
