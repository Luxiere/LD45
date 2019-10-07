using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inactive : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
