using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MultiColorPalette))]
public class MultipaletteEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MultiColorPalette myScript = (MultiColorPalette)target;
        if (GUILayout.Button("Generate Colors"))
        {
            myScript.Generate();
        }
    }
}