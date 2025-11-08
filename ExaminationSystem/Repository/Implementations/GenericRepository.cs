using ExaminationSystem.Data;
using ExaminationSystem.Models;
using ExaminationSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExaminationSystem.Repository.Implementations
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseModel
    {
        private readonly AppDbContext _context;
        DbSet<Entity> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }


        //----------------------Get All Non-Deleted Entities----------------------
        public IQueryable<Entity> GetAll()
        {
            return _dbSet.Where(x => !x.IsDeleted);
        }

        //---------------------- Get By Expression ------------------------------
        public IQueryable<Entity> Get(Expression<Func<Entity, bool>> expression)
        {
            return GetAll().Where(expression);
        }

        //----------------------Get Entity By Id---------------------------------
        public async Task<Entity?> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        //---------------------------- Add --------------------------------------
        public async Task Add(Entity T)
        {
            _dbSet.Add(T);
            await _context.SaveChangesAsync();
        }

        //---------------------------- Update -----------------------------------
        public async Task Update(Entity T)
        {
            _dbSet.Update(T);
            await _context.SaveChangesAsync();
        }

        //------------------------- Soft Delete ---------------------------------
        public async Task<bool> SoftDelete(int updatedById, int entityId)
        {
            var rows = await _dbSet
                .Where(e => e.Id == entityId && !e.IsDeleted)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(e => e.IsDeleted, true)
                    .SetProperty(e => e.UpdatedBy, updatedById)
                    .SetProperty(e => e.UpdatedDate, DateTime.Now));

            return rows > 0;
        }




    }
}
