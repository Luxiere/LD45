using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] plants = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawning(int spawnIndex)
    {
        GameObject spawnling = Instantiate(plants[spawnIndex], transform.position, transform.rotation);
        spawnling.transform.parent = transform;
    }
}
