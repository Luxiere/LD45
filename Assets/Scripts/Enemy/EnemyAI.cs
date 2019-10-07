using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float minMoveCallInterval = 2f;
    [SerializeField] float maxMoveCallInterval = 5f;
    [SerializeField] float waypointTolerance = .5f;
    [SerializeField] float waypointDwellingTime = 2f;
    [SerializeField] EnemyStats stats = null;
    [SerializeField] EnemyPathing[] pathing = null;

    bool isMoving = true;
    bool pauseMovement = false;
    int waypointIndex = 0;
    float waitTime;
    float waypointArrivalTime = Mathf.Infinity;

    Transform plant;
    EnemyPathing currentPathing;

    private void Awake()
    {
        plant = GameObject.FindWithTag("Player").transform;
        RandomPathing();
        RandomWaitTime();
    }

    private void Update()
    {
        UpdateTimer();
        if (isMoving)
        {
            MovingBehavior();
            return;
        }
        if (pauseMovement) return;
        waitTime -= Time.deltaTime;
        if (waitTime < 0) StartMovement();
    }

    public void DoDamage()
    {
        stats.TakeDamage();
    }

    public void StartMovement()
    {
        isMoving = true;
        waypointIndex = 0;
        RandomPathing();
    }

    public void PauseMovement()
    {
        pauseMovement = true;
    }

    public void StopMovement()
    {
        isMoving = false;
    }

    private void RandomPathing()
    {
        currentPathing = pathing[Random.Range(0, pathing.Length - 1)];
    }

    private void RandomWaitTime()
    {
        waitTime = Random.Range(minMoveCallInterval, maxMoveCallInterval);
    }

    public void ContinueMovement()
    {
        isMoving = true;
        pauseMovement = true;
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
            if (waypointIndex == -1)
            {
                StopMovement();
                RandomWaitTime();
                return;
            }
            if (AtWaypoint())
            {
                waypointDwellingTime = 0f;
                CycleWaypoint();
            }
            if (waypointIndex != -1) nextWaypoint = GetCurrentWaypoint();
        }
        if (waypointArrivalTime >= waypointDwellingTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, stats.speed * Time.deltaTime);
            transform.LookAt(nextWaypoint);
        }
    }

    private bool AtWaypoint()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
        return distanceToWaypoint <= waypointTolerance;
    }

    private void CycleWaypoint()
    {
        waypointIndex = currentPathing.GetNextWaypoint(waypointIndex);
    }

    private Vector3 GetCurrentWaypoint()
    {
        return currentPathing.GetWaypoint(waypointIndex);
    }
}
