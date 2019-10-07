using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRay : MonoBehaviour
{
    private void Update()
    {
        bool hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity);
        if (hasHit)
        {
            SunlightBar sunlightBar = hit.transform.GetComponent<SunlightBar>();
            if (sunlightBar)
            {
                sunlightBar.GainLight();
            }
        }
    }
}
