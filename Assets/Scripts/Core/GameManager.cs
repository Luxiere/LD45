using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent winEvent = null;
    [SerializeField] UnityEvent loseEvent = null;

    public void Lose()
    {
        loseEvent.Invoke();
    }
}