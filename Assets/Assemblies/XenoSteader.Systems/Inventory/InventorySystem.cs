using System.Collections.Generic;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;

namespace Assets.Assemblies.XenoSteader.Systems.Inventory
{
    public class InventorySystem
    {
        private List<Item> _items;

        public InventorySystem()
        {
            _items = new List<Item>();
        }

        /// <summary>
        /// Get a read only sequence of items.
        /// </summary>
        public IEnumerable<Item> Items => _items;

        /// <summary>
        /// Remove a reference to an item from the list
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItemFromInventory(Item item) => _items.Remove(item);

        /// <summary>
        /// Add a single reference to an item to the list
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToInventory(Item item) => _items.Add(item);

        /// <summary>
        /// Add a enumerable of references to the inventory
        /// </summary>
        /// <param name="items"></param>
        public void AddItemsToInventory(IEnumerable<Item> items) => _items.AddRange(items);
    }
}
