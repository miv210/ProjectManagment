using ProjectManagment_WEBAPI.Models;

namespace ProjectManagment_WEBAPI.Repository
{
    public interface IProjectRepository
    {
        public List<Project> GetAll();
        //public TDbModel Get(Guid id);
        //public TDbModel Create(TDbModel model);
        //public TDbModel Update(TDbModel model);
        //public void Delete(Guid id);
    }
}
