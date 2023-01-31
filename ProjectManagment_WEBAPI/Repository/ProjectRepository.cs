using ProjectManagment_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ProjectManagment_WEBAPI.Repository
{
    public class ProjectRepository: IProjectRepository
    {
        Project_ManagmentContext Context;

        public ProjectRepository(Project_ManagmentContext context)
        {
            Context = context;
        }

        public Project Create(Project project)
        {
            Context.Add(project);
            Context.SaveChanges();
            return project;
        }

        public void Delete(int id)
        {
            var toDelete = Context.Projects.Where(p => p.Id == id);
            Context.Remove(toDelete);
            Context.SaveChanges();
        }

        public List<Project> GetAll()
        {
            return Context.Projects.Include(p=> p.IdManagerNavigation).ToList();
        }

        public Project Update(Project project)
        {
            var toUpdate = Context.Projects.FirstOrDefault(p => p.Id == project.Id);
            if(toUpdate != null)
            {
                toUpdate = project;
            }
            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }

        public Project Get(int id)
        {
            return Context.Projects.FirstOrDefault(p => p.Id == id);
        }
    }
}
