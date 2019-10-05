using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBar : MonoBehaviour
{
    [SerializeField] int maxHealthPoints = 100;
    [SerializeField] int decayRate = 5;

    int currentHealthPoints;
    float currentTimer = 1f; //decayRate is per second

    void Start()
    {
        currentHealthPoints = maxHealthPoints;
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            LoseWater(decayRate);
            currentTimer = 1f;
        }
    }

    private void DeathCheck()
    {
        if (currentHealthPoints <= 0)
        {
            FindObjectOfType<GameManager>().Lose();
        }
    }

    public float GetWaterFraction() { return currentHealthPoints / maxHealthPoints; }

    public void AddWater(int value)
    {
        currentHealthPoints = Mathf.Min(currentHealthPoints += value, maxHealthPoints);
    }

    public void LoseWater(int value)
    {
        currentHealthPoints = Mathf.Max(currentHealthPoints -= value, 0);
        DeathCheck();
    }
}
