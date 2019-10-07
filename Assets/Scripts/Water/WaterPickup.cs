using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : MonoBehaviour, IClickable
{
    [SerializeField] int addAmount = 10;

    public void Click()
    {
        WaterBar water = GameObject.FindWithTag("Water").GetComponent<WaterBar>();
        water.AddWater(addAmount * Time.deltaTime);
    }

    public CursorType GetCursorType()
    {
        return CursorType.Water;
    }
}
