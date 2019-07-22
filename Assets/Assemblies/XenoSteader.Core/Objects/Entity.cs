using System;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects
{
    // Unity heavily requires Serializable attributes.
    [Serializable]
    public abstract class Entity : ScriptableObject
    {
        public string Name { get; set; }
        public Sprite Sprite { get; set; }
    }
}
