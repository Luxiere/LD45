using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(GetWaypoint(i + 1), GetWaypoint(i));
        }
    }

    public int GetNextWaypoint(int i)
    {
        if (i + 1 == transform.childCount) { return -1; }
        return i + 1;
    }

    public Vector3 GetWaypoint(int i)
    {
        return transform.GetChild(i).position;
    }
}
