using System;
using System.Collections.Generic;

namespace ProjectManagment_WEBAPI.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectsWorkers = new HashSet<ProjectsWorker>();
        }

        public int Id { get; set; }
        public string NameProject { get; set; } = null!;
        public string NameCustomerCompany { get; set; } = null!;
        public string NameImplementerCompany { get; set; } = null!;
        public int? IdWorkeк { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public int? ProjectPriority { get; set; }
        public int? IdManager { get; set; }

        public virtual Worker? IdManagerNavigation { get; set; }
        public virtual ICollection<ProjectsWorker> ProjectsWorkers { get; set; }
    }
}
