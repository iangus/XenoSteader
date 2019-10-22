using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities.Collections
{
    [Serializable]
    public abstract class EntityCollection<T> : Entity, IList<T> where T : Entity
    {
        [SerializeField]
        protected List<T> _innerList;

        private Dictionary<Type, List<T>> _referencesBySubType;
        [SerializeField]
        public int Count => _innerList.Count;
        public bool IsReadOnly => false;

        protected EntityCollection()
        {
            _innerList = new List<T>();
            _referencesBySubType = new Dictionary<Type, List<T>>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                return;
            }

            _innerList.Add(entity);
            var typeOfT = typeof(T);
            if (!_referencesBySubType.ContainsKey(typeOfT))
            {
                _referencesBySubType.Add(typeOfT, new List<T>());
            }
            _referencesBySubType[typeOfT].Add(entity);
        }

        public virtual void Clear()
        {
            _innerList.Clear();
        }

        public virtual bool Contains(T entity)
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

        public virtual bool Remove(T entity)
        {
            return _innerList.Remove(entity);
        }

        public virtual int IndexOf(T entity)
        {
            return _innerList.IndexOf(entity);
        }

        public virtual void Insert(int index, T entity)
        {
            _innerList.Insert(index, entity);
        }

        public virtual void RemoveAt(int index)
        {
            _innerList.RemoveAt(index);
        }

        public T this[int index]
        {
            get => _innerList[index];
            set => _innerList[index] = value;
        }

        /// <summary>
        /// Return All the values in the entity collection that return from T
        /// </summary>
        /// <typeparam name="TSub"></typeparam>
        /// <returns></returns>
        public IEnumerable<TSub> GetSubTypeValues<TSub>() 
            where TSub : T => GetSubTypeValues<TSub>(false);

        /// <summary>
        /// Get all the types that inherit from T,
        /// including a bool to get all the types that are subtypes of T
        /// </summary>
        /// <param name="inheritFromT"></param>
        /// <returns></returns>
        public IEnumerable<TSub> GetSubTypeValues<TSub>(bool inheritFromT) where TSub : T
        {
            if (inheritFromT)
            {
                return _innerList
                       .Where(item => item.GetType() == typeof(T) || item.GetType().IsSubclassOf(typeof(T)))
                       .Cast<TSub>();
            }

            if (_referencesBySubType.TryGetValue(typeof(T), out var tSubList))
            {
                return tSubList.Cast<TSub>();
            }

            return Enumerable.Empty<TSub>();
        }
    }
}
