using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class RequirementService
    {
        private readonly IHttpContextAccessor _http;

        public RequirementService(IHttpContextAccessor http)
        {
            _http = http;
        }

        public string GetCurrentUser()
        {
            return _http.HttpContext?.User?.Identity?.Name;
        }
    }
}
