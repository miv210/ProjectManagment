using System;
using System.Collections.Generic;

namespace ProjectManagment_WEBAPI.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
            ProjectsWorkers = new HashSet<ProjectsWorker>();
        }

        public int Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ProjectsWorker> ProjectsWorkers { get; set; }
    }
}
