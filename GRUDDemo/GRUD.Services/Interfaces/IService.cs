using System;
using System.Collections.Generic;
using System.Text;
 
namespace GRUDDemo.Services
{
	/// <summary>
	/// 標準Service介面
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface IService<TEntity>
		where TEntity : class
	{
		/// <summary>
		/// 新增單筆資料
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		IResult Create(TEntity entity);

		/// <summary>
		/// 修改單筆資料
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		IResult Update(TEntity entity);

		/// <summary>
		/// 刪除單筆資料
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		IResult Delete(TEntity entity);
	}
}
