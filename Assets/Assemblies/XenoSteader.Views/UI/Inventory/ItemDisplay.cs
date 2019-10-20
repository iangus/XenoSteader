using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using Assets.Assemblies.XenoSteader.Events.Inventory;
using TMPro;

namespace Assets.Assemblies.XenoSteader.View.UI.Inventory
{
    public class ItemDisplay : MonoBehaviour
    {
        public TextMeshProUGUI itemNameText;
        public TextMeshProUGUI quantityText;
        public Image itemImage;
        public Item item;

        public ItemEvent dropEvent;
        
        void Update()
        {
            itemNameText.text = item.Name;
            quantityText.text = "x" + item.quantity;
            itemImage.sprite = item.Sprite;
        }

        public void OnDropClick() {
            dropEvent.Raise(item);
        }
    }
}

