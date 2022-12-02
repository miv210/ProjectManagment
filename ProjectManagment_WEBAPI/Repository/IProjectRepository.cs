using ProjectManagment_WEBAPI.Models;

namespace ProjectManagment_WEBAPI.Repository
{
    public interface IProjectRepository<TDbModel> where TDbModel : BaseModel
    {
        public List<TDbModel> GetAll();
        public TDbModel Get(Guid id);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(Guid id);
    }
}
