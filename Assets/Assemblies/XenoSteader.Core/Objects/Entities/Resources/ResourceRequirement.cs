using System;
using Assets.Assemblies.XenoSteader.Core.Objects.Utilities;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities.Resources
{
    [Serializable]
    [CreateAssetMenu(menuName = "Crafting/ResourceRequirement")]
    public class ResourceRequirement : Entity
    {
        public ResourceType ResourceType;
        public IntVariable RequiredResourceNumber;

        public bool Equals(Resource resource) 
        {
            return resource != null && ResourceType == resource.ResourceType;
        }
    }
}
