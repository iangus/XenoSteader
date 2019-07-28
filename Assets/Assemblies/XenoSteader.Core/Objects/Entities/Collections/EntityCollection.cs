using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities.Collections
{
    [Serializable]
    public abstract class EntityCollection<T> : Entity, IList<T> where T : Entity
    {
        [SerializeField]
        private List<T> _innerList;
        [SerializeField]
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

        public void AddRange(IEnumerable<T> entities)
        {
            _innerList.AddRange(entities);
        }

        public void Add(T entity)
        {
            _innerList.Add(entity);
        }

        public void Clear()
        {
            _innerList.Clear();
        }

        public bool Contains(T entity)
        {
            return _innerList.Contains(entity);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var k = 0;
            for (var i = arrayIndex; i < array.Length; i++, k++)
            {
                array[k] = _innerList[i];
            }
        }

        public bool Remove(T entity)
        {
            return _innerList.Remove(entity);
        }

        public int IndexOf(T entity)
        {
            return _innerList.IndexOf(entity);
        }

        public void Insert(int index, T entity)
        {
            _innerList.Insert(index, entity);
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
