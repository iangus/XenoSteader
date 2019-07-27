using System;
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

        public void Awake()
        {
            Inventory = AbstractSystem.CreateInstance<InventorySystem>();
        }
    }
}
