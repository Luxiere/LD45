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
    public UnityEvent returned = null;

    private bool firstFrame = true;

    Animator animator;
    WaterBar waterBar;
    Vector3 init_pos;

    private void Start()
    {
        animator = GetComponent<Animator>();
        init_pos = transform.position;
    }

    public IEnumerator WaterRoutine()
    {
        while (!MoveTowards(waterPos.position))
        {
            yield return null;
        }

        animator.SetBool("watering", true);

        yield return new WaitForSeconds(waterTime);
        agent.isStopped = false;

        stopWatering.Invoke();
        animator.SetBool("watering", false);

        while (!MoveTowards(init_pos))
        {
            yield return null;
        }
        returned.Invoke();
    }

    public void Reset()
    {
        agent.enabled = false;
        agent.enabled = true;
    }

    public void Water()
    {
        waterEvent.Invoke();
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
