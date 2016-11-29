using ASPPatterns.Chap7.Library.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.Library.Model
{
    public interface IBaseRepository<T>
    {
        void Add(T model);
        void Remove(T model);
        void Save(T model);

        Book FindBy(Guid Id);

        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(int index, int count);

        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);
    }
}
