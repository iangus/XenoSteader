using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities.Resources;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities.Crafting
{
    [CreateAssetMenu(menuName = "Crafting/CraftingRecipes")]
    [Serializable]
    public class CraftingRecipe : Entity
    {
        public List<ResourceRequirement> ResourceRequirements;
        private Dictionary<ResourceType, int> _resourceTypesAndAmounts;
        public CraftingRecipe()
        {
            ResourceRequirements = new List<ResourceRequirement>();
        }

        public virtual bool CanCraft(ICollection<Resource> resources)
        {
            var resourceTypes = resources.Select(resource => resource.ResourceType);
            return ContainsAllResources(resourceTypes) && HasEnoughResources(resources);
        }

        private bool ContainsAllResources(IEnumerable<ResourceType> resourceTypes)
        {
            return ResourceRequirements
                .All(resourceRequirement => resourceTypes.Contains(resourceRequirement.ResourceType));
        }

        private bool HasEnoughResources(IEnumerable<Resource> resources)
        {
            var resourceTuples = resources.Select(
                resource => new Tuple<Resource, ResourceRequirement>(
                    resource, ResourceRequirements
                        .Single(resourceRequirement => resourceRequirement.ResourceType == resource.ResourceType)));
            return resourceTuples.All(tuple => tuple.Item1.StackSize > tuple.Item2.RequiredResourceNumber);
        }
    }
}
