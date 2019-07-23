using JetBrains.Annotations;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Resources
{
    public class Resource : Item
    {
        /// <summary>
        /// Denotes the # of items in the stack,
        /// </summary>
        public int StackSize;

        public ResourceType ResourceType;

        public Resource()
        {
            StackSize = 0;
        }

        public bool TryAddResourceToStack([NotNull] Resource resource)
        {
            if (resource.ResourceType == ResourceType)
            {
                StackSize
            }
            StackSize++;
        }

        public bool TryRemoveItemsFromStack(int numberToRemove)
        {
            if (StackSize >= numberToRemove)
            {
                StackSize -= numberToRemove;
                return true;
            }

            return false;
        }
    }
}
