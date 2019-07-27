using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Behaviors
{
    [RequireComponent(typeof(SphereCollider))]
    public class ItemPickupComponent : MonoBehaviour
    {
        public InventoryComponent InventoryListener;
        private ItemPickupEvent _pickupEvent;

        public void Start()
        {
            _pickupEvent = new ItemPickupEvent();
            _pickupEvent.AddListener(InventoryListener.Inventory.AddItemToInventory);
        }

        public void OnCollisionEnter(Collision collision)
        {
            var droppablePickup = collision.gameObject.GetComponent<Droppable>();
            if (droppablePickup != null)
            {
                _pickupEvent.Invoke(droppablePickup.Item);
            }
        }
    }
}
