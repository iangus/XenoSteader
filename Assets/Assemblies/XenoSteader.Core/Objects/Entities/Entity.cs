using System;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects
{
    // Unity heavily requires Serializable attributes.
    [CreateAssetMenu]
    public abstract class Entity : ScriptableObject
    {
        public string Name { get; set; }
    }
}
