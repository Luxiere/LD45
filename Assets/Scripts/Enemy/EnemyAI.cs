using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float waypointTolerance = .5f;
    [SerializeField] float waypointDwellingTime = 2f;
    [SerializeField] EnemyStats stats = null;
    [SerializeField] EnemyPathing pathing = null;

    bool isMoving = true;
    int waypointIndex = 0;
    float waypointArrivalTime = Mathf.Infinity;

    Transform plant;

    private void Awake()
    {
        plant = GameObject.FindWithTag("Player").transform;        
    }

    private void Update()
    {
        UpdateTimer();
        if(isMoving) MovingBehavior();
    }

    public void StopMovement()
    {
        isMoving = false;
    }

    private void UpdateTimer()
    {
        waypointArrivalTime += Time.deltaTime;
    }

    private void MovingBehavior()
    {
        Vector3 nextWaypoint = plant.position;
        if(pathing != null)
        {
            if (AtWaypoint())
            {
                waypointDwellingTime = 0f;
                CycleWaypoint();
            }
            nextWaypoint = GetCurrentWaypoint();
        }
        if (waypointArrivalTime >= waypointDwellingTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, stats.speed * Time.deltaTime);
        }
    }

    private bool AtWaypoint()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
        return distanceToWaypoint <= waypointTolerance;
    }

    private void CycleWaypoint()
    {
        waypointIndex = pathing.GetNextWaypoint(waypointIndex);
    }

    private Vector3 GetCurrentWaypoint()
    {
        return pathing.GetWaypoint(waypointIndex);
    }
}
