using System.Collections;
using System.Collections.Generic;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Events.Inventory
{
    [CreateAssetMenu]
    public class ItemEvent : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<IItemEventListener> eventListeners = 
            new List<IItemEventListener>();

        public void Raise(Item item)
        {
            for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnItemEventRaised(item);
        }

        public void RegisterListener(IItemEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(IItemEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}
