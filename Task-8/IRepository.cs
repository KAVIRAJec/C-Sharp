using System;
using System.Collections.Generic;

namespace Task_8
{
    internal interface IRepository<T> where T : class
    {
        void Add(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(int id, T item);
        void Delete(int id);
    }
}
