using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities.Resources;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities.Crafting
{
    [CreateAssetMenu(menuName = "CraftingRecipes")]
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
            var matchingResources = resources.Where(c => ResourceRequirements.Any(t => t.Equals(c)));
            var resourceTypes = resources.Select(t => t.ResourceType);
            return ContainsAllResources(resourceTypes) && HasEnoughResources(resources);
        }

        private bool ContainsAllResources(IEnumerable<ResourceType> resourceTypes)
        {
            return ResourceRequirements.All(c => resourceTypes.Contains(c.ResourceType));
        }

        private bool HasEnoughResources(IEnumerable<Resource> resources)
        {
            var resourceTuples = resources.Select(
                c => new Tuple<Resource, ResourceRequirement>(
                    c, ResourceRequirements.Single(t => t.ResourceType == c.ResourceType)));
            return resourceTuples.All(c => c.Item1.StackSize > c.Item2.RequiredResourceNumber);
        }
    }
}
