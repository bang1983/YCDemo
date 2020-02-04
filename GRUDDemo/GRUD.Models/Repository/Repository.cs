using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace GRUDDemo.Models
{
	public class Repository<TEntity> : IRepository<TEntity>
		 where TEntity : class
	{
		public DemoDBContext MyContext { get; private set; }
		public DbSet<TEntity> MyEntity
		{
			get
			{
				return MyContext.Set<TEntity>();
			}
		}

		/// <summary>
		/// 建構式
		/// </summary>
		/// <param name="context">注入資料連線</param>
		public Repository(DemoDBContext context)
		{
			MyContext = context;
		}

		#region 新增

		public int Create(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException();

			this.MyContext.Set<TEntity>().Add(entity);

			return this.MyContext.SaveChanges();
		}
 

		public async Task<int> CreateAsync(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException();

			this.MyContext.Set<TEntity>().Add(entity);

			return await this.MyContext.SaveChangesAsync();
		}
  
		#endregion

		// ..

		#region 修改

		public int Update(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException();

			this.MyContext.Entry(entity).State = EntityState.Modified;

			return this.MyContext.SaveChanges();

		}

		#endregion

		// ..

		#region 刪除

		public int Delete(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException();

			this.MyContext.Entry(entity).State = EntityState.Deleted;

			return this.MyContext.SaveChanges();
		}
 
 
		#endregion

		// ..

		#region 查詢

		public TEntity GetID(params object[] keyValues)
		{
			return this.MyContext.Set<TEntity>().Find(keyValues);
		}

		public IQueryable<TEntity> GetAll()
		{
			return this.MyContext.Set<TEntity>().AsQueryable();
		}

		public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
		{
			return this.MyContext.Set<TEntity>().Where(predicate);
		}

		#endregion
	}
}
