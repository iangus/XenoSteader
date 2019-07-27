using System;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Assemblies.XenoSteader.Behaviors
{
    [RequireComponent(typeof(SphereCollider))]
    public class ItemPickupComponent : MonoBehaviour
    {
        private readonly ItemPickupEvent _pickupEvent;
        private GameObject _currentlyCollidingGameObject;

        public ItemPickupComponent()
        {
            _pickupEvent = new ItemPickupEvent();
        }

        public void OnCollisionEnter(Collision collision)
        {
            var droppablePickup = collision.gameObject.GetComponent<Droppable>();
            if (collision.gameObject != _currentlyCollidingGameObject && droppablePickup != null)
            {
                _currentlyCollidingGameObject = collision.gameObject;
                _pickupEvent.Invoke(droppablePickup.Item);
                // Destroy is not immediate, 
                // So we have to store the reference to the item we're hitting,
                // or the sphere collider will hit it twice.
                Destroy(collision.gameObject);
            }
        }

        public void OnCollisionExit(Collision collision)
        {
            _currentlyCollidingGameObject = null;
        }

        public void SubscribeForPickupEvents(UnityAction<Item> callBack)
        {
            _pickupEvent.AddListener(callBack);
        }
    }
}
