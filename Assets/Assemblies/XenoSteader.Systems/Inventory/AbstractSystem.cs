namespace Assets.Assemblies.XenoSteader.Systems.Inventory
{
    public abstract class AbstractSystem
    {
        /// <summary>
        /// Defacto Constructor for Abstract System's
        /// This is to allow rigging of unity resources that can only happen on the main thread.
        /// This is only accessed via CreateInstance.
        /// </summary>
        /// <returns></returns>
        protected abstract AbstractSystem Init();

        /// <summary>
        /// Create an instance of a child class of AbstractSystem.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateInstance<T>() where T : AbstractSystem, new()
        {
            var t = new T();
            t.Init();
            return t;
        }
    }
}
