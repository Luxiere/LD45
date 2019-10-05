using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    [SerializeField] RectTransform foreground = null;
    private void Update()
    {
        Vector3 healthBarScale = foreground.localScale;
        foreground.localScale = new Vector3(healthBarScale.x, GetComponent<WaterBar>().GetWaterFraction(), healthBarScale.z);
    }
}
