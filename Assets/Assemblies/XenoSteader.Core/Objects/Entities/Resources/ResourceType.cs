using System;

namespace Assets.Assemblies.XenoSteader.Core.Objects
{
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
