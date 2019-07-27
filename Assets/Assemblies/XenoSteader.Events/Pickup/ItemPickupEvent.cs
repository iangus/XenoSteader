using System;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities;
using UnityEngine.Events;

[Serializable]
public class ItemPickupEvent : UnityEvent<Item>
{
}