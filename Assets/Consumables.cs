using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Consumables : MonoBehaviour
{
    [SerializeField] int pricing = 20;
    [SerializeField] Text text = null;
    [SerializeField] UnityEvent events = null;

    GameObject player;

    public void PriceCheck()
    {
        if(player.GetComponent<SunlightBar>().GetCurrentPoints() >= pricing)
        {
            events.Invoke();
            player.GetComponent<SunlightBar>().LoseLight(pricing);
        }
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        text.text = pricing.ToString();
    }
}
