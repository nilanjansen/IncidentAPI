using System;
using System.Collections.Generic;

namespace DeltaEndpoint.Models
{
    public partial class Incident
    {
        public int IncidentId { get; set; }
        public string CreatorContact { get; set; }
        public string IssueType { get; set; }
        public string Location { get; set; }
    }
}
