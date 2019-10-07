using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightBar : MonoBehaviour
{

    [SerializeField] int maxLightPoints = 100;
    [SerializeField] int gainRate = 3;

    int currentLightPoints;
    float currentTimer = 1f; //gainRate is per second

    void Start()
    {
        currentLightPoints = maxLightPoints;
    }

    private void Update()
    {
        if (!DayNightCycle.isDay) return;
        GainLight();
    }

    public int GetCurrentPoints()
    {
        return currentLightPoints;
    }

    public void GainLight()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            AddLight(gainRate);
            currentTimer = 1f;
        }
    }

    public void SpendLight(int value)
    {
        if (currentLightPoints >= value)
        {
            LoseLight(value);
        }
    }

    public void AddLight(int value)
    {
        currentLightPoints = Mathf.Min(currentLightPoints += value, maxLightPoints);
    }

    public void LoseLight(int value)
    {
        currentLightPoints = Mathf.Max(currentLightPoints -= value, 0);
    }
}
