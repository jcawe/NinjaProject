using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class AxisEvent : UnityEvent<float> { }

[Serializable]
public class ButtonEvent : UnityEvent<bool> { }

public class ControlBehaviour : MonoBehaviour
{
    public AxisEvent OnHorizontalAxis;
    public AxisEvent OnVerticalAxis;
    public ButtonEvent OnRun;
    public ButtonEvent OnCancel;

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var run = Input.GetButton("Run");
        var cancel = Input.GetButtonDown("Cancel");

        OnHorizontalAxis?.Invoke(x);
        OnVerticalAxis?.Invoke(y);
        OnRun?.Invoke(run);
        OnCancel?.Invoke(cancel);
    }
}
