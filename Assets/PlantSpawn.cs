using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawn : MonoBehaviour
{
    public GameObject[] plants = null;

    public GameObject Spawning(int spawnIndex)
    {
        GameObject spawnling = Instantiate(plants[spawnIndex], plants[spawnIndex].transform.position, plants[spawnIndex].transform.rotation);
        spawnling.transform.parent = transform;
        return spawnling;
    }
}
