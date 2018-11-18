using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBladderBehaviour : MonoBehaviour
{
    public Transform WC;
    public float minWCDistance;
    public UnityEvent OnPeeingStart;
    public UnityEvent OnPeeingFinish;
    private NavMeshAgent agent;
    private bool peeing;
    private bool haveToPeeing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(!haveToPeeing || peeing) return;
        
        var dist = Mathf.Abs((transform.position - WC.position).magnitude);
        if(dist < minWCDistance) StartCoroutine("Peeing");
    }

    public void GotoWC()
    {
        OnPeeingStart?.Invoke();
        Debug.Log("Goin to WC");
        agent.SetDestination(WC.position);
        haveToPeeing = true;
    }

    IEnumerator Peeing()
    {
        peeing = true;
        Debug.Log("Peeing...");
        yield return new WaitForSeconds(5f);
        Debug.Log("Peeing finish");
        OnPeeingFinish?.Invoke();
        haveToPeeing = false;
        peeing = false;
    }
}
