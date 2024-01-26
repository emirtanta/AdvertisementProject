using AdvertisementProject.Common.Enums;
using AdvertisementProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// verileri liste şeklinde getirir
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// verileri şarta göre liste şeklinde getirir
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector,OrderByType orderByType=OrderByType.DESC);

        /// <summary>
        /// girilen şartlara göre verileri liste şeklinde getirir
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="filter"></param>
        /// <param name="selector"></param>
        /// <param name="orderByType"></param>
        /// <returns></returns>
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);

        /// <summary>
        /// id değerine göre veri getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> FindAsync(object id);

        /// <summary>
        /// girilen şarta göre bir adet veri getirir
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="asNoTracking"></param>
        /// <returns></returns>
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);

        /// <summary>
        /// veri getirir
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetQuery();

        /// <summary>
        /// veri siler
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// veri ekler
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(T entity);

        /// <summary>
        /// veri günceller
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unchanged"></param>
        void Update(T entity, T unchanged);
    }
}
