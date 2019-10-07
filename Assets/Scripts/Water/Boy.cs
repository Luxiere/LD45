using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Boy : MonoBehaviour
{
    [SerializeField] float waterTime = 5f;
    [SerializeField] Transform waterPos = null;
    [SerializeField] UnityEvent waterEvent = null;
    [SerializeField] UnityEvent stopWatering = null;


    WaterBar waterBar;
    NavMeshAgent agent;
    Vector3 init_pos;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        init_pos = transform.position;
    }

    public IEnumerator WaterRoutine()
    {
        while (true)
        {
            if(MoveTowards(waterPos.position)) break;
        }
        waterEvent.Invoke();
        yield return new WaitForSeconds(waterTime);
        stopWatering.Invoke();
        while (true)
        {
            if (MoveTowards(init_pos)) break;
        }
    }

    private bool MoveTowards(Vector3 destination)
    {
        agent.destination = destination;
        if (Mathf.Approximately(agent.remainingDistance, 0) || Mathf.Approximately(agent.remainingDistance, Mathf.Infinity))
        {
            return true;
        }
        return false;
    }
}
