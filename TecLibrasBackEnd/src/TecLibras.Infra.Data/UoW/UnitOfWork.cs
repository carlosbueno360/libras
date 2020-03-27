using TecLibras.Domain.Interfaces;
using TecLibras.Infra.Data.Context;

namespace TecLibras.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TecLibrasContext _context;

        public UnitOfWork(TecLibrasContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
