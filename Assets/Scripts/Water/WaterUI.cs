using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    Image foreground;
    WaterBar player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<WaterBar>();
        foreground = GetComponent<Image>();
    }

    private void Update()
    {
        foreground.fillAmount = player.GetWaterFraction();
    }
}
