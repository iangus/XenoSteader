using System;
using System.Collections.Generic;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities.Collections;
using Assets.Assemblies.XenoSteader.Events.Inventory;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Systems.Inventory
{
    [Serializable]
    public class InventorySystem : AbstractSystem, IItemEventListener
    {
        [SerializeField]
        protected ItemCollection EntityCollection;
        [SerializeField]

        private ItemEvent _itemEvent;

        public ItemEvent itemEvent
        {
            get => _itemEvent;
            set => _itemEvent = value;
        }

        public void OnItemEventRaised(Item item) {
            RemoveItemFromInventory(item);
        }

        private void OnEnable()
        {
            _itemEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            _itemEvent.UnregisterListener(this);
        }

        /// <summary>
        /// Get a read only sequence of items.
        /// </summary>
        public IEnumerable<Item> Items => EntityCollection;

        /// <summary>
        /// Remove a reference to an item from the list
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItemFromInventory([NotNull] Item item) => EntityCollection.Remove(item);

        /// <summary>
        /// Add a single reference to an item to the list
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToInventory([NotNull] Item item) => EntityCollection.Add(item);

        /// <summary>
        /// Add a enumerable of references to the inventory
        /// </summary>
        /// <param name="items"></param>
        public void AddItemsToInventory([NotNull] IEnumerable<Item> items) => EntityCollection.AddRange(items);

        protected override AbstractSystem Init()
        {
            EntityCollection = ScriptableObject.CreateInstance<ItemCollection>();
            return this;
        }
    }
}
