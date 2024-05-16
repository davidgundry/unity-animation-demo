using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlatformBehaviour))]
public class PlatformBehaviourEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        PlatformBehaviour pb = (PlatformBehaviour) target;

        EditorGUI.BeginDisabledGroup(!(pb.IsUp && Application.isPlaying));
        if (GUILayout.Button("Trigger Fall"))
            pb.Fall();
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup(!(!pb.IsUp && Application.isPlaying));
        if (GUILayout.Button("Reset"))
            pb.Reset();
        EditorGUI.EndDisabledGroup();
    }
}