using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities
{
    public abstract class Item : Entity
    {
        // The line between 3d stuff and items is a bit weird. We might have things that are 3d and items, 
        // But will never go into an inventory. I see this as how rimworld handles some structures
        // 3d objects, but cannot ever be an 'item'
        // So the way item currently exists today is without context to the 3d component
        public string ItemType { get; }

        /// <summary>
        /// Sprite of an item to display in an inventory UI
        /// </summary>
        public Sprite Sprite { get; set; }
    }
}
