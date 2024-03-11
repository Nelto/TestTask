
using Microsoft.EntityFrameworkCore;

namespace TestTask.Model.Abstract
{
    public class EFRepos<T> : IRepos<T> where T : BaseEntity
    {
        private DbContext dBcontext;

        public EFRepos(DbContext dBcontext)
        {
            this.dBcontext = dBcontext;
        }

        public async Task Add(T entity)
        {
            await dBcontext.Set<T>().AddAsync(entity);
            await dBcontext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await dBcontext.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
            if (entity != null)
            {
                dBcontext.Set<T>().Remove(entity);
                await dBcontext.SaveChangesAsync();
            }
        }

        public async Task<T?> Get(Guid id)
        {
            return await dBcontext.Set<T>().FirstOrDefaultAsync(p =>p.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dBcontext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            //dBcontext.Set<T>().Update(entity);
            await dBcontext.SaveChangesAsync();
        }
    }
}
