using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class rain : MonoBehaviour
{
    [SerializeField] int minDaysTillRain = 2;
    [SerializeField] int maxDaysTillRain = 4;
    [SerializeField] float waterGainPerSec = 10f;
    [SerializeField] UnityEvent rains = null;
    [SerializeField] UnityEvent stopRains = null;

    public static bool isRaining = false;

    GameObject player;

    int currentDaysTillRain = -1;

    private void Awake()
    {
        currentDaysTillRain = RandomRainDays();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (isRaining)
        {
            player.GetComponent<WaterBar>().AddWater(waterGainPerSec * Time.deltaTime);
        }
    }

    private int RandomRainDays()
    {
        return UnityEngine.Random.Range(minDaysTillRain, maxDaysTillRain);
    }

    public void DayPast()
    {
        currentDaysTillRain -= 1;
        if (currentDaysTillRain <= 0)
        {
            Raining();
        }
    }

    private void Raining()
    {
        isRaining = true;
        rains.Invoke();
    }

    public void StopRaining()
    {
        isRaining = false;
        stopRains.Invoke();
        RandomRainDays();
    }

}
