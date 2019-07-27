using System.Collections;
using System.Collections.Generic;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities.Collections
{
    public class EntityCollection<T> : Entity, IList<T> where T : Entity
    {
        private readonly List<T> _innerList;
        public int Count => _innerList.Count;
        public bool IsReadOnly => false;

        public EntityCollection()
        {
            _innerList = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(IEnumerable<T> items)
        {
            _innerList.AddRange(items);
        }

        public void Add(T item)
        {
            _innerList.Add(item);
        }

        public void Clear()
        {
            _innerList.Clear();
        }

        public bool Contains(T item)
        {
            return _innerList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var k = 0;
            for (var i = arrayIndex; i < array.Length; i++, k++)
            {
                array[k] = _innerList[i];
            }
        }

        public bool Remove(T item)
        {
            return _innerList.Remove(item);
        }

        public int IndexOf(T item)
        {
            return _innerList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _innerList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _innerList.RemoveAt(index);
        }

        public T this[int index]
        {
            get => _innerList[index];
            set => _innerList[index] = value;
        }
    }
}
