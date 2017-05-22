using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using Spring.Data.NHibernate.Generic.Support;

namespace Dao.Implement
{
    public abstract class RepositoryBase<T> : HibernateDaoSupport,IRepository<T> where T : class 
    {
        public T Get(object id)
        {
            return this.HibernateTemplate.Get<T>(id);
        }

        public T Load(object id)
        {
            return this.HibernateTemplate.Load<T>(id);
        }

        public object Save(T entity)
        {
            return this.HibernateTemplate.Save(entity);
        }

        public void Update(T entity)
        {
            this.HibernateTemplate.Update(entity);
        }

        public void SaveOrUpdate(T entity)
        {
            this.HibernateTemplate.SaveOrUpdate(entity);
        }

        public void Delete(object id)
        {
            var entity = this.HibernateTemplate.Get<T>(id);
            if (entity == null)
            {
                return;
            }
            this.HibernateTemplate.Delete(entity);
        }

        public void Delete(IList<object> idList)
        {
            foreach (var item in idList)
            {
                var entity = this.HibernateTemplate.Get<T>(item);
                if (entity == null)
                {
                    return;
                }
                this.HibernateTemplate.Delete(entity);
            }
        }

        public IQueryable<T> LoadAll()
        {
            var result = Session.Query<T>();
            return result;
        }

        public IQueryable<T> LoadAllWithPage(out long count, int pageIndex, int pageSize)
        {
            var result = Session.Query<T>();
            count = result.LongCount();
            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
