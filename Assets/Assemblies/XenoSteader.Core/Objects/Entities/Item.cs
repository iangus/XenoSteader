using System;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities
{
    [CreateAssetMenu]
    [Serializable]
    public class Item : Entity
    {
        // The line between 3d stuff and items is a bit weird. We might have things that are 3d and items, 
        // But will never go into an inventory. I see this as how rimworld handles some structures
        // 3d objects, but cannot ever be an 'item'
        // So the way item currently exists today is without context to the 3d component
        [SerializeField] private string _itemType;

        public string ItemType
        {
            get => _itemType;
            set => _itemType = value;
        }

        public int quantity;

        /// <summary>
        /// Sprite of an item to display in an inventory UI
        /// </summary>
        [SerializeField] private Sprite _sprite;

        public Sprite Sprite
        {
            get => _sprite;
            set => _sprite = value;
        }
    }
}
