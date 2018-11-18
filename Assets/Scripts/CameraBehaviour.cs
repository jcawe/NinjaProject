using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform Target;
    public Vector3 OffSet;
    public float Zoom;

    void LateUpdate()
    {
        var position = Target.position - OffSet * Zoom;
        transform.position = position;

        transform.LookAt(Target.position);
    }
}
