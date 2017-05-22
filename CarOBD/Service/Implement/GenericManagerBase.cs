using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Implement
{
    public abstract class GenericManagerBase<T>:IGenericManager<T> where T:class 
    {
        public Dao.IRepository<T> CurrentRepository { get; set; } 

        public T Get(object id)
        {
            if (id == null)
            {
                return null;
            }
            return this.CurrentRepository.Get(id);
        }

        public T Load(object id)
        {
            if (id == null)
            {
                return null;
            }
            return this.CurrentRepository.Load(id);

        }

        public object Save(T entity)
        {
            if (entity == null)
            {
                return null;
            }
            return this.CurrentRepository.Save(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                return;
            }
            this.CurrentRepository.Update(entity);
        }

        public void SaveOrUpdate(T entity)
        {
            if (entity == null)
            {
                return;
            }
            this.CurrentRepository.SaveOrUpdate(entity);
        }

        public void Delete(object id)
        {
            if (id == null)
            {
                return;
            }
            this.CurrentRepository.Delete(id);
        }

        public void Delete(IList<object> idList)
        {
            if (idList == null || idList.Count == 0)
            {
                return;
            }
            this.CurrentRepository.Delete(idList);
        }

        public IList<T> LoadAll()
        {
            return this.CurrentRepository.LoadAll().ToList();
        }

        public IList<T> LoadAllWithPage(out long count, int pageIndex, int pageSize)
        {
            return this.CurrentRepository.LoadAllWithPage(out count, pageIndex, pageSize).ToList();
        }
    }
}
