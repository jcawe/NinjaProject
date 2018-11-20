using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DetectedEvent : UnityEvent<GameObject> { }
public class ViewSensorBehaviour : MonoBehaviour
{
    public DetectedEvent OnDetected;
    public float ViewRadius;
    public float ViewAngle;
    public LayerMask TargetMask;
    public LayerMask ObstaclesMask;
    public Vector3 DirOfAngle(float angle) => new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));

    public List<Transform> targetsDetected = new List<Transform>();

    void FixedUpdate()
    {
        FindTargets();
    }
    
    void FindTargets()
    {
        targetsDetected.Clear();
        var targetsInView = Physics.OverlapSphere(transform.position, ViewRadius, TargetMask).Select(x => x.transform);

        foreach (var target in targetsInView)
        {
            var dirTarget = (target.position - transform.position).normalized;
            var angle = Vector3.Angle(transform.forward, dirTarget);

            if (angle < ViewAngle / 2)
            {
                var dist = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirTarget, dist, ObstaclesMask))
                {
                    targetsDetected.Add(target);
                    OnDetected?.Invoke(target.gameObject);
                }
            }
        }
    }
}
