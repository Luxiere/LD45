using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnamentsController : MonoBehaviour
{
    [System.Serializable]
    public class OrnamentTable
    {
        public float timeBetweenWatering = 0f;
        public int ornamentPointsRequired = 0;
    }

    [SerializeField] OrnamentTable[] ornamentTables = null;
    [SerializeField] int waterGain = 15;

    public static bool isWatering = false;

    private int currentOrnamentPoints = 0;
    private float maxWaterIntervalTime;
    private float currentWaterIntervalTime = Mathf.Infinity;

    private WaterBar plant;
    private Boy boy;

    private void Awake()
    {
        plant = GameObject.FindWithTag("Player").GetComponent<WaterBar>();
        boy = GameObject.FindWithTag("Boy").GetComponent<Boy>();
    }

    private void Update()
    {
        currentWaterIntervalTime += Time.deltaTime;
        if (currentWaterIntervalTime >= maxWaterIntervalTime && !isWatering)
        {
            currentWaterIntervalTime = 0;
            Water();
            maxWaterIntervalTime = GetWaterTime();
        }
    }

    private void Water()
    {
        isWatering = true;
        plant.AddWater(waterGain);
        StartCoroutine(boy.WaterRoutine());
    }

    private void CanWater()
    {
        isWatering = false;
    }

    private float GetWaterTime()
    {
        if (currentOrnamentPoints >= ornamentTables[ornamentTables.Length -1].ornamentPointsRequired) return ornamentTables[ornamentTables.Length - 1].timeBetweenWatering;
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
