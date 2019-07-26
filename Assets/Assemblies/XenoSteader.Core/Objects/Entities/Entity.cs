using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities
{
    // Unity heavily requires Serializable attributes.
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
    public abstract class Entity : ScriptableObject
    {
        public string Name { get; set; }
    }
}
