using AdvertisementProject.DataAccess.Contexts;
using AdvertisementProject.DataAccess.Interfaces;
using AdvertisementProject.DataAccess.Repositories;
using AdvertisementProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AdvertisementContext _context;

        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
