using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace GRUDDemo.Models
{
	/// <summary>
	/// 容器
	/// </summary>
	/// <typeparam name="TEntity">實體</typeparam>
	public interface IRepository<TEntity>
		 where TEntity : class
	{
		/// <summary>
		/// DBContext
		/// </summary>
		DemoDBContext MyContext { get; }

		/// <summary>
		/// 取得該物件的實體
		/// </summary>
		DbSet<TEntity> MyEntity { get; }

		#region 新增

		/// <summary>
		/// 新增[存檔]
		/// </summary>
		/// <param name="entity">實體</param>
		/// <returns></returns>
		int Create(TEntity entity);
 
		/// <summary>
		/// 新增[存檔][非同步]
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		Task<int> CreateAsync(TEntity entity);
 
		#endregion

		// ..

		#region 修改

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity">實體</param>
		/// <returns></returns>
		int Update(TEntity entity);

		#endregion

		// ..

		#region 刪除

		/// <summary>
		/// 刪除
		/// </summary>
		/// <param name="entity">實體</param>
		/// <returns></returns>
		int Delete(TEntity entity);
 

		#endregion

		// ..

		#region 查詢
		/// <summary>
		/// 取得單筆資料
		/// </summary>
		/// <param name="keyValues"></param>
		/// <returns></returns>
		TEntity GetID(params object[] keyValues);

		/// <summary>
		/// 取得多筆資料
		/// </summary>
		/// <returns></returns>
		IQueryable<TEntity> GetAll();

		/// <summary>
		/// 取得多筆資料(LINQ)
		/// </summary>
		/// <param name="predicate">LINQ</param>
		/// <returns></returns>
		IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

		#endregion
	}
}
