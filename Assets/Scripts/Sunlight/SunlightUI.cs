using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunlightUI : MonoBehaviour
{
    Text text;
    SunlightBar bar;
    private void Awake()
    {
        bar = GameObject.FindWithTag("Player").GetComponent<SunlightBar>();
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = string.Format("{0}", bar.GetCurrentPoints());
    }
}
