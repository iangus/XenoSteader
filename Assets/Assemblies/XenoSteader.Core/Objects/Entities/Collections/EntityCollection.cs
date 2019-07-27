using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities.Collections
{
    [Serializable]
    [CreateAssetMenu]
    // leaving the name as entity collection until I figure out a way to fix this...
    public class EntityCollection : Entity, IList<Item>
    {
        [SerializeField]
        private readonly List<Item> _innerList;
        [SerializeField]
        public int Count => _innerList.Count;
        public bool IsReadOnly => false;

        public EntityCollection()
        {
            _innerList = new List<Item>();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(IEnumerable<Item> items)
        {
            _innerList.AddRange(items);
        }

        public void Add(Item item)
        {
            _innerList.Add(item);
        }

        public void Clear()
        {
            _innerList.Clear();
        }

        public bool Contains(Item item)
        {
            return _innerList.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            var k = 0;
            for (var i = arrayIndex; i < array.Length; i++, k++)
            {
                array[k] = _innerList[i];
            }
        }

        public bool Remove(Item item)
        {
            return _innerList.Remove(item);
        }

        public int IndexOf(Item item)
        {
            return _innerList.IndexOf(item);
        }

        public void Insert(int index, Item item)
        {
            _innerList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _innerList.RemoveAt(index);
        }

        public Item this[int index]
        {
            get => _innerList[index];
            set => _innerList[index] = value;
        }
    }
}
