using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Assemblies.XenoSteader.Core.Objects;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI quantityText;
    public Image itemImage;
    public Item item;
    
    void Update()
    {
        itemNameText.text = item.name;
        quantityText.text = "x" + item.quantity;
        itemImage.sprite = item.sprite;
    }
}
