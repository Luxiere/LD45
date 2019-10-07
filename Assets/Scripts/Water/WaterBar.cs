using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBar : MonoBehaviour
{
    [SerializeField] float maxHealthPoints = 100;
    [SerializeField] float decayRate = 5;

    float currentHealthPoints = Mathf.Infinity;

    void Awake()
    {
        currentHealthPoints = maxHealthPoints;
    }

    private void Update()
    {
        LoseWater(decayRate * Time.deltaTime);
    }

    private void DeathCheck()
    {
        if (currentHealthPoints <= 0)
        {
            FindObjectOfType<GameManager>().Lose();
        }
    }

    public float GetWaterFraction() { return currentHealthPoints / maxHealthPoints; }

    public void AddWater(float value)
    {
        currentHealthPoints = Mathf.Min(currentHealthPoints += value, maxHealthPoints);
    }

    public void LoseWater(float value)
    {
        currentHealthPoints = Mathf.Max(currentHealthPoints -= value, 0);
        DeathCheck();
    }
}
