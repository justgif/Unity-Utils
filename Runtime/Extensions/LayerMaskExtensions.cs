using UnityEngine;

namespace Utils.Extensions
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Checks if the LayerMask contains the specified layer index.
        /// </summary>
        /// <param name="layerMask">The LayerMask to check.</param>
        /// <param name="index">The index of the layer to check.</param>
        /// <returns>True if the LayerMask contains the specified layer index, otherwise false.</returns>
        public static bool Contains(this LayerMask layerMask, int index)
        {
            return layerMask == (layerMask | (1 << index));
        }
    }
}
