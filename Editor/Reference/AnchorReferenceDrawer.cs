using UnityEditor;
using UnityEngine;
using Xprees.RuntimeAnchors.Base.Reference;

namespace Xprees.RuntimeAnchors.Editor.Reference
{
    [CustomPropertyDrawer(typeof(AnchorReferenceBase<>), true)]
    public class AnchorReferenceDrawer : PropertyDrawer
    {
        private readonly string[] _popupOptions = { "Inlined Value", "Anchor" };
        private GUIStyle _popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
            {
                imagePosition = ImagePosition.ImageOnly,
            };

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();
            // Get properties
            var useInlined = property.FindPropertyRelative("useInlined");
            var inlinedValue = property.FindPropertyRelative("inlinedValue");
            var anchor = property.FindPropertyRelative("anchor");

            // Calculate rect for configuration button
            var buttonRect = new Rect(position);
            buttonRect.yMin += _popupStyle.margin.top;
            buttonRect.width = _popupStyle.fixedWidth + _popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var result = EditorGUI.Popup(buttonRect, useInlined.boolValue ? 0 : 1, _popupOptions, _popupStyle);

            useInlined.boolValue = result == 0;

            EditorGUI.PropertyField(position, useInlined.boolValue ? inlinedValue : anchor, GUIContent.none);


            if (EditorGUI.EndChangeCheck()) property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

    }
}