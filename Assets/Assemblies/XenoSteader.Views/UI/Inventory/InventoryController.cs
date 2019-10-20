using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.View.UI.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        public void OnCloseClick() {
            gameObject.SetActive(false);
        }
    }
}

