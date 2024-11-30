using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityUtils.Attributes;

namespace UnityUtils.Editor.Drawers
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class MethodButtonDrawer : UnityEditor.Editor
    {
        private const string k_DebugPrefix = "<b><color=#d4ac0d>Method Button</color></b>";

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            MonoBehaviour monoBehaviour = (MonoBehaviour)target;
            MethodInfo[] methods = monoBehaviour.GetType().GetMethods(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            string lastHeader = null;

            foreach (MethodInfo method in methods)
            {
                MethodHeaderAttribute headerAttribute = method.GetCustomAttribute<MethodHeaderAttribute>();
                MethodButtonAttribute buttonAttribute = method.GetCustomAttribute<MethodButtonAttribute>();

                if (buttonAttribute == null)
                    continue;
                
                // Render header if it's different from the last one
                if (headerAttribute != null && headerAttribute.Header != lastHeader)
                {
                    GUILayout.Space(10);
                    GUILayout.Label(headerAttribute.Header, EditorStyles.boldLabel);
                    lastHeader = headerAttribute.Header;
                }

                // Render button with method name
                if (!GUILayout.Button(ObjectNames.NicifyVariableName(method.Name)))
                    continue;
                
                // Check if the method requires the game to be running
                if (buttonAttribute.RequiresGameRunning && !Application.isPlaying)
                {
                    Debug.LogWarning($"{k_DebugPrefix}: {method.Name} requires the game to be running.");
                    return;
                }
                
                // Invoke the method
                method.Invoke(monoBehaviour, null);
            }
        }
    }
}
