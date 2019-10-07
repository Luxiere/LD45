using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlant : MonoBehaviour
{
    Transform plant;
    void Start()
    {
        plant = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(plant);
    }
}
