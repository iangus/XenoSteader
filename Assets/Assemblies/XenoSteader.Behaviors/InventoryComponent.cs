using Assets.Assemblies.XenoSteader.Systems.Inventory;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Behaviors
{
    public class InventoryComponent : MonoBehaviour
    {
        public InventorySystem Inventory { get; private set; }

        public void Awake()
        {
            Inventory = new InventorySystem();
        }
    }
}
