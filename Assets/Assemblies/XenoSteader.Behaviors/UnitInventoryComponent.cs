using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Behaviors
{
    // The 'Unit' Inventory is the inventory of a entity that picks up item and actively manages it's inventory
    // Vs say, the inventory component of an NPC that will have a set of items that will drop on their death.
    [RequireComponent(typeof(ItemPickupComponent))]
    public class UnitInventoryComponent : InventoryComponent
    {
        public override void Awake()
        {
            base.Awake();
            var pickupComponent = GetComponent<ItemPickupComponent>();
            pickupComponent.SubscribeForPickupEvents(Inventory.AddItemToInventory);
        }
    }
}
