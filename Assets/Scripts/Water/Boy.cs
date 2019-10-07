using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Boy : MonoBehaviour
{
    [SerializeField] float waterTime = 5f;
    [SerializeField] Transform waterPos = null;
    [SerializeField] NavMeshAgent agent = null;

    public UnityEvent waterEvent = null;
    public UnityEvent stopWatering = null;

    private bool firstFrame = true;

    WaterBar waterBar;
    Vector3 init_pos;

    private void Start()
    {
        init_pos = transform.position;
    }

    public IEnumerator WaterRoutine()
    {
        while (!MoveTowards(waterPos.position))
        {
            yield return null;
        }

        waterEvent.Invoke();

        yield return new WaitForSeconds(waterTime);

        stopWatering.Invoke();
        agent.isStopped = false;


        while (!MoveTowards(init_pos))
        {
            yield return null;
        }
    }

    private bool MoveTowards(Vector3 destination)
    {
        agent.destination = destination;
        if (firstFrame)
        {
            firstFrame = false;
            return false;
        }
        if (Mathf.Approximately(agent.remainingDistance, 0))
        {            
            agent.isStopped = true;
            firstFrame = true;
            return true;
        }
        return false;
    }
}
