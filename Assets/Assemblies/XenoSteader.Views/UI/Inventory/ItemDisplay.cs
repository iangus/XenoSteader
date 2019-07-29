using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using TMPro;

namespace Assets.Assemblies.XenoSteader.View.UI.Inventory
{
    public class ItemDisplay : MonoBehaviour
    {
        public TextMeshProUGUI itemNameText;
        public TextMeshProUGUI quantityText;
        public Image itemImage;
        public Item item;
        
        void Update()
        {
            itemNameText.text = item.Name;
            quantityText.text = "x" + item.quantity;
            itemImage.sprite = item.Sprite;
        }
    }
}

