using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Assemblies.XenoSteader.Core.Objects.Resources;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Crafting
{
    public class CraftingRecipe : Entity
    {
        public ICollection<Tuple<ResourceType, int>> ResourceTypesAndAmounts;

        public CraftingRecipe()
        {
            ResourceTypesAndAmounts = new List<Tuple<ResourceType, int>>();
        }

        public virtual bool CanCraft(IEnumerable<Resource> Resources)
        {
            return Resources.Where(c => ResourceTypesAndAmounts.Contains(c.))
        }
    }
}
