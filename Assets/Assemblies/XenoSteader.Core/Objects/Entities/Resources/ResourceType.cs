using System;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities.Resources
{
    [Serializable]
    [CreateAssetMenu]
    public class ResourceType : Entity, IEquatable<ResourceType>
    {
        public string ResourceName;
        public bool Equals(ResourceType other)
        {
            if (other == null)
            {
                return false;
            }
            
            return ResourceName == other.ResourceName;
        }
    }
}
