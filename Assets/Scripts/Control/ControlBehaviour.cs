using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class AxisEvent : UnityEvent<Vector3> { }

[Serializable]
public class ButtonEvent : UnityEvent<bool> { }

public class ControlBehaviour : MonoBehaviour
{
    public AxisEvent OnAxis;
    public ButtonEvent OnRun;

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var run = Input.GetButton("Run");

        OnRun?.Invoke(run);
        OnAxis?.Invoke(new Vector3(x, 0, y));
    }
}
