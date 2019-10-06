using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ornaments : MonoBehaviour
{
    [System.Serializable]
    public class OrnamentTable
    {
        public float timeBetweenWatering = 0f;
        public int ornamentPointsRequired = 0;
    }

    [SerializeField] OrnamentTable[] ornamentTables = null;
    [SerializeField] int waterGain = 15;

    private int currentOrnamentPoints = 0;
    private float maxWaterIntervalTime;
    private float currentWaterIntervalTime = Mathf.Infinity;

    private WaterBar plant;

    private void Awake()
    {
        plant = GameObject.FindWithTag("Player").GetComponent<WaterBar>();
    }

    private void Update()
    {
        currentWaterIntervalTime += Time.deltaTime;
        if (currentWaterIntervalTime >= maxWaterIntervalTime)
        {
            currentWaterIntervalTime = 0;
            Water();
            maxWaterIntervalTime = GetWaterTime();
        }
    }

    private void Water()
    {
        plant.AddWater(waterGain);
    }

    private float GetWaterTime()
    {
        if (currentOrnamentPoints >= ornamentTables[ornamentTables.Length].ornamentPointsRequired) return ornamentTables[ornamentTables.Length].timeBetweenWatering;
        for (int i = 0; i < ornamentTables.Length; i++)
        {
            if (currentOrnamentPoints >= ornamentTables[i].ornamentPointsRequired && currentOrnamentPoints < ornamentTables[i].ornamentPointsRequired)
            {
                return ornamentTables[i].timeBetweenWatering;
            }
        }
        return 0;
    }
}
