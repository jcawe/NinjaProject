using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PatrolAIBehaviour))]
public class PatrolAIEditor : Editor
{
    PatrolAIBehaviour Target => (PatrolAIBehaviour)target;

    void OnSceneGUI()
    {
        if(Target.Waypoints.Length == 0) return;
        Handles.color = Color.yellow;

        Vector3? lastWaypoint = null;
        foreach(var waypoint in Target.Waypoints)
        {
            if(lastWaypoint.HasValue) Handles.DrawDottedLine(lastWaypoint.Value, waypoint, 5f);

            Handles.DrawWireDisc(waypoint, Vector3.up, 1f);
            lastWaypoint = waypoint;
        }

        if(Target.Loop) Handles.DrawDottedLine(lastWaypoint.Value, Target.Waypoints[0], 5f);
    }
}
