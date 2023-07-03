using DSD_CMS.Model.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD_CMS.Model.ViewModels
{
    public class DevicesVm
    {
        public Devices Devices { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> DealersList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ShowroomsList { get; set; }
    }
}
