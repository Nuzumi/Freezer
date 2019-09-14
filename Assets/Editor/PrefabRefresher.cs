using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Fridge;

[CustomEditor(typeof(PrefabReferences))]
public class PrefabRefresher : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PrefabReferences prefabReferences = (PrefabReferences)target;
        if (GUILayout.Button("Refresh"))
        {
            prefabReferences.Refresh();
        }
    }
}
