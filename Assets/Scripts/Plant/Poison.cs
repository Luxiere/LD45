using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField] float activeTime = 20f;
    [SerializeField] ParticleSystem bubble = null;
    [SerializeField] GameObject button = null;

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

    private void OnDisable()
    {
        button.SetActive(true);
        bubble.Stop();
    }

    private void OnEnable()
    {
        button.SetActive(false);
        bubble.Play();
    }
}
