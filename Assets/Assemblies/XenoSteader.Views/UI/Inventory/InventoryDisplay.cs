﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities.Collections;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using JetBrains.Annotations;

namespace Assets.Assemblies.XenoSteader.View.UI.Inventory
{
    public class InventoryDisplay : MonoBehaviour
    {
        public GameObject ItemDisplayTemplate;
        private List<GameObject> _itemDisplays;

        [SerializeField]
        private ItemCollection _items;

        public ItemCollection Items
        {
            get => _items;
            set => _items = value;
        }

        // Start is called before the first frame
        void Start()
        {
            _itemDisplays = new List<GameObject>();
            foreach (Item item in _items)
            {
                _itemDisplays.Add(BuildItemDisplay(item));
            }
        }

        // Update is called once per frame
        void Update()
        {
            // TODO check if item list has changed. If so update what items are displayed.
            // How are we going to implement change detection, or just recreate the list every frame? Seems like an expensive operation.
            // Maybe reset the items every frame, but only instantiate/destroy the GameObject if the number of items doesn't match up?
            // In the future an inventory may have a limited amount of slots. Empty slots just wouldn't have items, so no need to instantiate/destroy on update.
            while(_itemDisplays.Count > _items.Count) {
                _itemDisplays.RemoveAt(_itemDisplays.Count - 1);
            }

            while(_itemDisplays.Count < _items.Count) {
                _itemDisplays.Add(BuildItemDisplay());
            }

            for (int i=0; i<_items.Count; i++)
            {
                Item item = _items[i];
                GameObject itemUIObject = _itemDisplays[i];
                SetItem(itemUIObject, item);
            }
        }

        GameObject BuildItemDisplay()
        {
            GameObject itemUIObject = Instantiate (ItemDisplayTemplate) as GameObject;

            itemUIObject.SetActive(true);

            itemUIObject.transform.SetParent(gameObject.transform, false);

            return itemUIObject;
        }

        GameObject  BuildItemDisplay(Item item) {
            GameObject itemUIObject = BuildItemDisplay();

            SetItem(itemUIObject, item);

            return itemUIObject;
        }

        void SetItem(GameObject itemUIObject, Item item)
        {
            itemUIObject.GetComponent<ItemDisplay>().item = item;
        }

    }
}

