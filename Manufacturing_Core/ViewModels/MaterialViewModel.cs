using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    public class MaterialViewModel
    {
        public int MaterialId { get; set; }

        public List<SelectListItem> MaterialList { get; set; }
    }
}
