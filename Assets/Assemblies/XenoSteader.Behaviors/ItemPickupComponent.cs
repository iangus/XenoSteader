using System;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Assemblies.XenoSteader.Behaviors
{
    [RequireComponent(typeof(SphereCollider))]
    public class ItemPickupComponent : MonoBehaviour
    {
        private ItemPickupEvent _pickupEvent;

        public void Start()
        {
            _pickupEvent = new ItemPickupEvent();
        }

        public void OnCollisionEnter(Collision collision)
        {
            var droppablePickup = collision.gameObject.GetComponent<Droppable>();
            if (droppablePickup != null)
            {
                _pickupEvent.Invoke(droppablePickup.Item);
            }
        }

        public void SubscribeForPickupEvents(UnityAction<Item> callBack)
        {
            _pickupEvent.AddListener(callBack);
        }
    }
}
