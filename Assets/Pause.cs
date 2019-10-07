using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    [SerializeField] UnityEvent pausing;
    [SerializeField] UnityEvent unpausing;

    public static bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) UnpauseGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pausing.Invoke();
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        unpausing.Invoke();
    }
}
