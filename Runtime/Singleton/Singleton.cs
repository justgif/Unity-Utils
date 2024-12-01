using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils.Singleton
{
    /// <summary>
    /// A base class for creating singletons.
    /// </summary>
    /// <typeparam name="T">The derived class that will inherit from <see cref="Singleton{T}"/></typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private const string k_DebugPrefix = "<b><color=#2ecc71>Singleton</color></b>";

        private static T s_Instance;
        
        [Header("Singleton Settings")]
        
        [SerializeField, Tooltip("Whether the singleton instance should persist between scene loading.")]
        private bool m_Persistent;
        
        public static T Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    // If the instance is null, try to find an existing instance
                    s_Instance = FindAnyObjectByType<T>();
                    
                    // If no instance was found, create a new instance
                    if (s_Instance == null)
                    {
                        Debug.LogWarning($"{k_DebugPrefix}: An instance of {typeof(T)} was not found. Creating a new instance.");
                        s_Instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    }
                }

                return s_Instance;
            }
        }
        
        /// <summary>
        /// Whether an instance of the singleton currently exists.
        /// </summary>
        public static bool HasInstance => s_Instance != null;

        /// <summary>
        /// Whether the singleton instance should persist between scene loading.
        /// </summary>
        public bool Persistent
        {
            set
            {
                m_Persistent = value;
                Debug.Log($"{k_DebugPrefix}: Set persistence of {GetType()} to {m_Persistent}.");
                
                if (!Application.isPlaying)
                    return;
                
                if (m_Persistent)
                {
                    transform.SetParent(null);
                    DontDestroyOnLoad(gameObject);
                }
                else
                {
                    SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
                }
            }
            get => m_Persistent;
        }
        
        protected virtual void Awake()
        {
            if (!Application.isPlaying)
                return;
            
            if (s_Instance == null)
            {
                s_Instance = this as T;

                // If the instance is persistent, don't destroy it on scene load
                if (m_Persistent)
                {
                    transform.SetParent(null);
                    DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                Debug.LogWarning($"{k_DebugPrefix}: An instance of {GetType()} already exists. Destroying {name}.");
                Destroy(gameObject);
            }
        }
        
        /// <summary>
        /// Attempts to get the singleton instance. Will not create a new instance if the singleton does not exist.
        /// </summary>
        /// <returns>The singleton instance if it exists, otherwise null.</returns>
        public static T TryGetInstance() => HasInstance ? s_Instance : null;
    }
}
