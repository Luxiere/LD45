using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRay : MonoBehaviour
{
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
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
