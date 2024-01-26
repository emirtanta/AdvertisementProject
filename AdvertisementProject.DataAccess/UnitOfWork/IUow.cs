using AdvertisementProject.DataAccess.Interfaces;
using AdvertisementProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T:BaseEntity;

        Task SaveChangeAsync();
    }
}
