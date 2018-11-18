using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BladderBehaviour : MonoBehaviour
{
    public BladderProfile Profile;
    public UnityEvent OnBladderFilled;
    private float bladder;
    bool notified;

    void OnEnable()
    {
        notified = false;
    }
    // Update is called once per frame
    void Update()
    {
        bladder += 1f * Time.deltaTime;

        bladder = Mathf.Clamp(bladder, 0f, 10f);

        if(bladder == 10f && !notified) 
        {
            notified = true;
            OnBladderFilled?.Invoke();
            Debug.Log("Bladder filled!");
        }
    }

    public void EmptyBladder()
    {
        bladder = 0f;
        Debug.Log("Bladder empty!");
        notified = false;
    }
}
