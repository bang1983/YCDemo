using System;
using System.Collections.Generic;
using System.Linq;
using GRUDDemo.Models;

namespace GRUDDemo.Services
{
    /// <summary>
    /// 實作Service
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Fields
        /// <summary>
        /// 泛型容器
        /// </summary>
        protected IRepository<TEntity> _repository { get; set; }
        #endregion

        #region Ctor
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods 
        /// <summary>
		/// 新增單筆資料
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
        public virtual IResult Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();

            IResult result = new Result();

            _repository.Create(entity);

            result.Success = true;

            return result;
        }

        /// <summary>
		/// 刪除單筆資料
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
        public virtual IResult Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();

            IResult result = new Result();

            _repository.Delete(entity);

            result.Success = true;

            return result;
        }

        /// <summary>
		/// 修改單筆資料
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
        public virtual IResult Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();

            IResult result = new Result();

            _repository.Update(entity);

            result.Success = true;

            return result;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll().AsEnumerable();
        }

        /// <summary>
        /// 取得PrimayKey資料
        /// </summary>
        /// <param name="Id">PrimayKey</param>
        /// <returns></returns>
        public virtual TEntity GetByID(Guid Id)
        {
            return _repository.GetID(Id);
        }
        #endregion
    }
}
