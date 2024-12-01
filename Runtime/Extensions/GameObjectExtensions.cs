using System.Linq;
using UnityEngine;

namespace Utils.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Gets or adds a component of type T to the GameObject.
        /// If the component already exists, it is returned.
        /// If the component does not exist, it is added to the GameObject and then returned.
        /// </summary>
        /// <typeparam name="T">The type of component to get or add.</typeparam>
        /// <param name="gameObject">The GameObject to get or add the component to.</param>
        /// <returns>The component of type T.</returns>
        public static T GetOrAdd<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            
            if (!component)
            {
                component = gameObject.AddComponent<T>();
            }
            
            return component;
        }

        /// <summary>
        /// Returns the scene path of the GameObject.
        /// The scene path is a string representation of the GameObject's hierarchy in the scene.
        /// </summary>
        /// <param name="gameObject">The GameObject to get the scene path for.</param>
        /// <returns>The scene path of the GameObject.</returns>
        public static string ScenePath(this GameObject gameObject)
        {
            return string.Join("/", gameObject.GetComponentsInParent<Transform>().Select(x => x.name).Reverse().ToArray());
        }
    }
}
