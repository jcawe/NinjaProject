using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBladderBehaviour : MonoBehaviour
{
    public float minWCDistance;
    public UnityEvent OnPeeingStart;
    public UnityEvent OnPeeingFinish;
    private NavMeshAgent agent;
    private bool peeing;
    private bool haveToPeeing;
    Vector3 peeSpot;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(!haveToPeeing || peeing) return;
        
        var dist = Mathf.Abs((transform.position - peeSpot).magnitude);
        if(dist < minWCDistance) StartCoroutine(Peeing());
    }

    public void GotoWC()
    {
        OnPeeingStart?.Invoke();
        peeSpot = FindNearestPeeSpot();
        agent.SetDestination(peeSpot);
        haveToPeeing = true;
    }

    Vector3 FindNearestPeeSpot()
    {
        var peeSpots = Object.FindObjectsOfType<PeeSpotBehaviour>().Select(x => x.transform.position);

        Vector3 result = Vector3.zero;
        float dist = -1f;
        foreach(var spot in peeSpots)
        {
            var spotDist = Vector3.Distance(transform.position, spot);
            if(dist < 0 || dist > spotDist)
            {
                dist = spotDist;
                result = spot;
            }
        }

        return result;
    }

    IEnumerator Peeing()
    {
        peeing = true;
        yield return new WaitForSeconds(5f);
        OnPeeingFinish?.Invoke();
        haveToPeeing = false;
        peeing = false;
    }
}
