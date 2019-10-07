using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField] float activeTime = 20f;

    float currentActiveTime = Mathf.Infinity;

    private void Update()
    {
        currentActiveTime += Time.deltaTime;
        if(currentActiveTime > activeTime)
        {
            currentActiveTime = 0f;
            enabled = false;
        }
    }
}
