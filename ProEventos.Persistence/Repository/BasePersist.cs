using ProEventos.Persistence.Context;
using ProEventos.Persistence.IRepository;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repository
{
    public class BasePersist : IBasePersist
    {
        private readonly ProEventosContext _context;

        public BasePersist(ProEventosContext context)
        {
            _context = context;
        }
        void IBasePersist.Add<T>(T entity)
        {
            _context.Add(entity);
        }

        void IBasePersist.Update<T>(T entity)
        {
            _context.Update(entity);
        }

        void IBasePersist.Delete<T>(T entity)
        {
            _context.Remove(entity);
        }
        void IBasePersist.DeleteRange<T>(T[] entityArray)
        {
            _context.RemoveRange(entityArray);
        }
        async Task<bool> IBasePersist.SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
