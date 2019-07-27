using System.Collections.Generic;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities.Collections;
using JetBrains.Annotations;

namespace Assets.Assemblies.XenoSteader.Systems.Inventory
{
    public class InventorySystem
    {
        private readonly EntityCollection<Item> _entityCollection;

        public InventorySystem()
        {
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
