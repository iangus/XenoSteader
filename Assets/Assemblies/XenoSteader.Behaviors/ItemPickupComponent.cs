using System;
using System.Collections.Generic;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Assemblies.XenoSteader.Behaviors
{
    [RequireComponent(typeof(SphereCollider))]
    public class ItemPickupComponent : MonoBehaviour
    {
        private readonly ItemPickupEvent _pickupEvent;
        // Destroy is not immediate, 
        // So we have to store the reference to the item we're hitting,
        // or the sphere collider will hit it twice.
        private HashSet<GameObject> _currentlyCollidingGameObjects;

        public ItemPickupComponent()
        {
            _currentlyCollidingGameObjects = new HashSet<GameObject>();
            _pickupEvent = new ItemPickupEvent();
        }

        public void OnCollisionEnter(Collision collision)
        {
            var droppablePickup = collision.gameObject.GetComponent<Droppable>();
            if (!_currentlyCollidingGameObjects.Contains(collision.gameObject) && droppablePickup != null)
            {
                _currentlyCollidingGameObjects.Add(collision.gameObject);
                _pickupEvent.Invoke(droppablePickup.Item);
                Destroy(collision.gameObject);
            }
        }

        public void OnCollisionExit(Collision collision)
        {
            _currentlyCollidingGameObjects.Remove(collision.gameObject);
        }

        public void SubscribeForPickupEvents(UnityAction<Item> callBack)
        {
            _pickupEvent.AddListener(callBack);
        }
    }
}
