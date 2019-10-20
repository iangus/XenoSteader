using System;
using System.Collections.Generic;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities.Collections;
using Assets.Assemblies.XenoSteader.Core.Objects.Entities.Crafting;
using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Systems.Crafting
{
    [Serializable]
    public class CraftingRecipeSet : AbstractSystem
    {
        [SerializeField]
        private CraftingCollection _craftingRecipes;

        public IEnumerable<CraftingRecipe> GetCraftingRecipes() => _craftingRecipes;

        protected override AbstractSystem Init()
        {
            if (_craftingRecipes == null)
            {
                _craftingRecipes = ScriptableObject.CreateInstance<CraftingCollection>();
            }
            return this;
        }
    }
}
