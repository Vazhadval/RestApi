using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Contracts.HealthChecks
{
    public class HealtCheck
    {
        public string Status { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
    }
}
