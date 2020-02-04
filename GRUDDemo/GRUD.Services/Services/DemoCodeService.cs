using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using GRUDDemo.Models;

namespace GRUDDemo.Services
{

    public class DemoCodeService : IDemoCodeService
    {
        private IRepository<DemoCode> _demoCodeRepos { get; set; }

        public DemoCodeService(IRepository<DemoCode> demoCodeRepos)
        {
            _demoCodeRepos = demoCodeRepos;
        }

        public IResult Create(DemoCode entity)
        {
            if (entity == null) throw new ArgumentNullException();

            IResult result = new Result();

            _demoCodeRepos.Create(entity);

            result.Success = true;

            return result;
        }

        public IResult Update(DemoCode entity)
        {
            if (entity == null) throw new ArgumentNullException();

            IResult result = new Result();

            var targetData = this.Get(entity.ID);

            if (targetData != null)
            {

                _demoCodeRepos.Update(targetData);

                result.Success = true;
            }
            else
            {
                result.Success = false;
            }

            return result;
        }

        public IResult Delete(DemoCode entity)
        {
            if (entity == null) throw new ArgumentNullException();

            IResult result = new Result();

            _demoCodeRepos.Delete(entity);
            result.Success = true;

            return result;
        }

        public DemoCode Get(Guid id)
        {
            return _demoCodeRepos.GetID(id);
        }

        public IQueryable<DemoCode> GetAll()
        {
            return _demoCodeRepos.GetAll();
        }

    }
}