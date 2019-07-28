namespace Assets.Assemblies.XenoSteader.Systems.Inventory
{
    public abstract class AbstractSystem
    {
        /// <summary>
        /// Abstract implementation of init to rig up scriptable objects
        /// or other Unity specific dependencies
        /// </summary>
        /// <typeparam name="T"></typeparam>
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
