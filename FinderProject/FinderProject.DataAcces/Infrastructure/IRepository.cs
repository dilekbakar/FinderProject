using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace FinderProject.DataAcces.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        //bu bizim tüm datamızı çekecek.
        List<T> GetAll();

        //tek bir nesne döndürür.
        T GetById(int d);

        T Create(T obj);

        T Update(T obj);

        void Delete(int id);

    }
}
