using System.Collections.Generic;
using System.Linq;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Assemblies.XenoSteader.Behaviors
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
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

        public void Start()
        {
            var rigidBody = GetComponent<Rigidbody>();
            // ReSharper disable once LocalVariableHidesMember
            var collider = GetComponents<Collider>().Single(c => c.GetType() != typeof(CharacterController));
            if (rigidBody.isKinematic)
            {
                collider.isTrigger = true;
            }
        }

        public void OnTriggerEnter(Collider triggerCollider)
        {
            var droppablePickup = triggerCollider.gameObject.GetComponent<Droppable>();
            if (!_currentlyCollidingGameObjects.Contains(triggerCollider.gameObject) && droppablePickup != null)
            {
                _currentlyCollidingGameObjects.Add(triggerCollider.gameObject);
                _pickupEvent.Invoke(droppablePickup.Item);
                Destroy(triggerCollider.gameObject);
            }
        }

        public void OnTriggerExit(Collider triggerCollider)
        {
            _currentlyCollidingGameObjects.Remove(triggerCollider.gameObject);
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
