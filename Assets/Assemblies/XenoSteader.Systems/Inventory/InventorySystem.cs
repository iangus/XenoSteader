using System;
using System.Collections.Generic;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Systems.Inventory
{
    [Serializable]
    public class InventorySystem
    {
        [SerializeField]
        protected EntityCollection<Item> _entityCollection;

        public InventorySystem()
        {
            // So apparently this throws an exception, because you're not supposed to call the constructor
            // But if you do ScriptableObject.CreateInstance<> it explodes. 
            // For now I'll leave this as it only throws on the game closing.
            _entityCollection = new EntityCollection<Item>();
        }

        /// <summary>
        /// Get a read only sequence of items.
        /// </summary>
        public IEnumerable<Item> Items => _entityCollection;

        /// <summary>
        /// Remove a reference to an item from the list
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItemFromInventory([NotNull] Item item) => _entityCollection.Remove(item);

        /// <summary>
        /// Add a single reference to an item to the list
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToInventory([NotNull] Item item) => _entityCollection.Add(item);

        /// <summary>
        /// Add a enumerable of references to the inventory
        /// </summary>
        /// <param name="items"></param>
        public void AddItemsToInventory([NotNull] IEnumerable<Item> items) => _entityCollection.AddRange(items);
    }
}
