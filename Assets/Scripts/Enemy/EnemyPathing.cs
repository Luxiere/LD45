using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int j = GetNextWaypoint(i);
            Gizmos.DrawLine(GetWaypoint(j), GetWaypoint(i));
        }
    }

    public int GetNextWaypoint(int i)
    {
        if (i + 1 == transform.childCount) { return 0; }
        return i + 1;
    }

    public Vector3 GetWaypoint(int i)
    {
        return transform.GetChild(i).position;
    }
}
