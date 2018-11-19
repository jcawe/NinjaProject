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
        bladder += Profile.Speed * Time.deltaTime;

        bladder = Mathf.Clamp(bladder, 0f, Profile.Max);

        if(bladder == Profile.Max && !notified) 
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

    [ExecuteInEditMode]
    void OnDrawGizmos()
    {
        var perc = bladder / (Profile?.Max ?? 1f);

        Gizmos.color = perc == 1 ? Color.red : Color.cyan;
        
        Gizmos.DrawWireSphere(transform.position + Vector3.up*2f, 0.2f);
        Gizmos.DrawSphere(transform.position + Vector3.up*2f,
             perc * 0.2f);
    }
}
