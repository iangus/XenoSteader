using Assets.Assemblies.XenoSteader.Core.Objects.Utilities;
using JetBrains.Annotations;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Entities.Resources
{
    public class Resource : Item
    {
        /// <summary>
        /// Denotes the # of items in the stack,
        /// </summary>
        public IntVariable StackSize;
        public ResourceType ResourceType;


        public bool TryAddResourceToStack([NotNull] Resource resource)
        {
            if (resource.ResourceType == ResourceType)
            {
                StackSize.Value += resource.StackSize;
                return true;
            }

            return false;
        }

        public bool TryRemoveItemsFromStack(int numberToRemove)
        {
            if (StackSize >= numberToRemove)
            {
                StackSize.Value -= numberToRemove;
                return true;
            }

            return false;
        }
    }
}
