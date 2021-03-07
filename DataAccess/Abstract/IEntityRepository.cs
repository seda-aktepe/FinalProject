using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constaint : Hangi entity concreteleri çağıracağını kısıtlamak anlamına gelir.
    //class : Referans tip
    //IEntity : IEntitiy olabilir veya IEntity implemente eden bir nesne olabilir.
    //new() : new'lenebilir. IEntity newlenemediği için, ona newleme yetkisi verdik.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
