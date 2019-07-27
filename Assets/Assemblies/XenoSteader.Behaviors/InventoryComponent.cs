using Assets.Assemblies.XenoSteader.Systems.Inventory;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Behaviors
{
    public abstract class InventoryComponent : MonoBehaviour
    {
        protected InventorySystem Inventory { get; private set; }

        public void Awake()
        {
            Inventory = new InventorySystem();
        }
    }
}
