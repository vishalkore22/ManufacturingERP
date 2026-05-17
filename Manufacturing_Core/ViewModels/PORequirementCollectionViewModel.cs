using Manufacturing_Core.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    public class PORequirementCollectionViewModel
    {
        public TrPORequirementCollection TrPORequirementCollection { get; set; }

        public List<SelectListItem> MaterialListItem { get; set; } 
    }
}
