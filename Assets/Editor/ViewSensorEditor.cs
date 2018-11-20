using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ViewSensorBehaviour))]
public class ViewSensorEditor : Editor
{
    ViewSensorBehaviour Target => (ViewSensorBehaviour)target;
    float ViewRadius => Target.ViewRadius;
    float ViewAngle => Target.ViewAngle;
    Vector3 Position => Target.transform.position;
    Vector3 Forward => Target.transform.forward;

    Vector3 DirOfAngle(float angle) => Target.DirOfAngle(angle + Target.transform.eulerAngles.y);

    void OnSceneGUI()
    {
        Handles.color = Color.white;
        var pointA = DirOfAngle(-ViewAngle / 2);
        var pointB = DirOfAngle(ViewAngle / 2);

        Handles.DrawWireArc(Position, Vector3.up, pointA, ViewAngle, ViewRadius);
        Handles.DrawLine(Position, Position + pointA * ViewRadius);
        Handles.DrawLine(Position, Position + pointB * ViewRadius);

        foreach (var viewTarget in Target.targetsDetected) DrawDetected(viewTarget);
    }

    public void DrawDetected(Transform detected)
    {
        Handles.color = Color.red;
        Handles.DrawLine(Position, detected.position);
        Handles.DrawWireDisc(detected.position, Vector3.up, 1);
    }
}
