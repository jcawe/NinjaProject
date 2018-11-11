using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class AxisEvent : UnityEvent<float> { }

public class ControlBehaviour : MonoBehaviour
{
    public AxisEvent OnHorizontalAxis;
    public AxisEvent OnVerticalAxis;
    public UnityEvent OnSubmit;
    public UnityEvent OnCancel;

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if (x != 0) OnHorizontalAxis?.Invoke(x);

        if (y != 0) OnVerticalAxis?.Invoke(y);

        if (Input.GetButtonDown("Submit")) OnSubmit?.Invoke();

        if (Input.GetButtonDown("Cancel")) OnCancel?.Invoke();
    }
}
