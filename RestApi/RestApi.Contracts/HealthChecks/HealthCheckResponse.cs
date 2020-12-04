using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Contracts.HealthChecks
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }
        public IEnumerable<HealtCheck> Checks { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
