using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GRUDDemo.Models;


namespace GRUDDemo.Services
{
    public interface IDemoCodeService : IService<DemoCode>
    {
        /// <summary>
        /// 依Primary Key取得代碼
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DemoCode Get(Guid id);

        /// <summary>
        /// 取得所有
        /// </summary> 
        /// <returns></returns>
        IQueryable<DemoCode> GetAll();

  

    }
}
