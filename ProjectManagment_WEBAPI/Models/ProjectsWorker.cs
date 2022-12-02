using System;
using System.Collections.Generic;

namespace ProjectManagment_WEBAPI.Models
{
    public partial class ProjectsWorker
    {
        public int Id { get; set; }
        public int? IdWorker { get; set; }
        public int? IdProject { get; set; }

        public virtual Project? IdProjectNavigation { get; set; }
        public virtual Worker? IdWorkerNavigation { get; set; }
    }
}
