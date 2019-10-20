using UnityEngine;

namespace Assets.Assemblies.XenoSteader.Core.Objects.Utilities
{
    public static class GameObjectExtensions
    {
        public static T GetComponentInHierarchy<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? gameObject.GetComponentInParent<T>() ?? gameObject.GetComponentInChildren<T>();
        }
    }
}
