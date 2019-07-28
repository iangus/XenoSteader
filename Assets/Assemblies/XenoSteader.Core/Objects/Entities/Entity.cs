using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities
{
    // Unity heavily requires Serializable attributes.
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
    [Serializable]
    public abstract class Entity : ScriptableObject
    {
        [SerializeField]
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}
