using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.Model.Models
{
    public class InsideInventory
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Inside Inventory Name")]
        public string InsideInventoryName { get; set; }
    }
}
