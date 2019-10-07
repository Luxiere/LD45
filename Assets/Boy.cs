using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boy : MonoBehaviour
{
    [SerializeField] float waterTime = 5f;
    [SerializeField] Transform waterPos = null;

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

    public void WaterRoutine()
    {
        MoveTowards(waterPos.position);
        Water()
    }

    private void MoveTowards(Vector3 destination)
    {
        agent.destination = destination;
    }
}
