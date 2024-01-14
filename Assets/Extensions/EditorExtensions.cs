using UnityEditor;
using UnityEngine;

namespace Platformer.Extensions
{
    public class EditorExtensions : MonoBehaviour
    {
        #region Read Only Attribute
        public class ReadOnlyAttribute : PropertyAttribute
        {

        }
        [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
        public class ReadOnlyPropertyDrawer : PropertyDrawer
        {
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                GUI.enabled = false;
                EditorGUI.PropertyField(position, property, label);
                GUI.enabled = true;
            }
        }
        #endregion
    }

}
