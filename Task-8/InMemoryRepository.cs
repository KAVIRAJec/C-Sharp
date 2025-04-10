using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8
{
    public class InMemoryRepository<T>: IRepository<T> where T : class, IEntity
    {
        private readonly Dictionary<int, T> items = new Dictionary<int, T>();
        private int currentId = 1;

        public void Add(T item)
        {
            item.Id = currentId++;
            items.Add(item.Id, item);
        }
        public T Get(int id)
        {
            items.TryGetValue(id, out T result);
            return result;
        }
        public IEnumerable<T> GetAll()
        {
            return items.Values;
        }
        public void Update(int id, T item)
        {
            if(items.ContainsKey(id))
            {
                //item.Id = id;
                items[id] = item;
            }
        }
        public void Delete(int id)
        {
            items.Remove(id);
        }


    }
}
