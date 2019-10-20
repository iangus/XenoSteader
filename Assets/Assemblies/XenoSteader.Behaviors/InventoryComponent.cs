using System;
using Assets.Assemblies.XenoSteader.Systems;
using Assets.Assemblies.XenoSteader.Systems.Inventory;
using UnityEditor;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Behaviors
{
    [Serializable]
    public abstract class InventoryComponent : MonoBehaviour
    {
        [SerializeField]
        protected InventorySystem Inventory;

        public virtual void Awake()
        {
            // If we already have one from the editor
            Inventory = AbstractSystem.CreateInstance<InventorySystem>();
        }
    }
}
