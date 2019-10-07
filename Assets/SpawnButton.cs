using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [System.Serializable]
    public class IntEvent: UnityEvent<int> { }

    [SerializeField] IntEvent events = null;
    [SerializeField] int[] lightPrices = null;

    int currentTreeIndex = 0;
    GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        SetPrice();
    }

    public void SetTreeIndex()
    {
        currentTreeIndex = gm.GetTreeIndex();
    }

    public void InvokeEvents()
    {
        events.Invoke(lightPrices[currentTreeIndex]);
    }

    public void SetPrice()
    {
        GetComponentInChildren<Text>().text = lightPrices[currentTreeIndex].ToString();
    }
}
