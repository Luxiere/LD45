using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] float daytime = 30f;
    [SerializeField] float nighttime = 30f;

    public static bool isDay = true;

    private float currentTime;
    private Vector3 init_Rot;

    float midDay = 0f;
    float midNight = 180f;
    float midDayAlt = 360f;

    private void Awake()
    {
        currentTime = daytime;
        init_Rot = transform.rotation.eulerAngles;
    }


    void Update()
    {
        Cycle();
        Debug.Log(isDay);
    }

    private void Cycle()
    {
        if (isDay)
        {
            DayCycle();
        }
        else
        {
            NightCycle();
        }
    }

    private void NightCycle()
    {
        transform.rotation = Quaternion.Euler(new Vector3(Mathf.Lerp(midDayAlt, midNight, currentTime / daytime), init_Rot.y, init_Rot.z));
        if (Timer())
        {
            currentTime = daytime;
            isDay = true;
        }
    }

    private void DayCycle()
    {
        transform.rotation = Quaternion.Euler(new Vector3(Mathf.Lerp(midNight, midDay, currentTime / daytime), init_Rot.y, init_Rot.z));
        if (Timer())
        {
            currentTime = nighttime;
            isDay = false;
        }
    }

    private bool Timer()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) return true;
        return false;
    }
}
