using ExaminationSystem.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.Repository.Interfaces
{
    public interface IGenericRepository<Entity> where Entity : BaseModel
    {
        IQueryable<Entity> GetAll();
        IQueryable<Entity> Get(Expression<Func<Entity, bool>> expression);
        Task<Entity?> GetById(int id);
        Task Add(Entity T);
        Task Update(Entity T);
        Task<bool> SoftDelete(int UpdatedById, int EntityId);
    }
}
