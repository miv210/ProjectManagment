using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagment_WEBAPI.Models;
using ProjectManagment_WEBAPI.Repository;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagment_WEBAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectRepository repProject;
        Project_ManagmentContext db;
        public ProjectController(Project_ManagmentContext context, IProjectRepository projectRepository)
        {          
            db= context;
            repProject= projectRepository; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectsWorker>>> Get()
        {
            return repProject.GetAll();

            //return  await db.ProjectsWorkers.Include(p => p.IdProjectNavigation).Include(p => p.IdWorkerNavigation).ToListAsync();
        }
    }
}
