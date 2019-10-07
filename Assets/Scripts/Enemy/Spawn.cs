using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject spawnlingPrefab = null;
    [SerializeField] int numberOfSpawns = 3;

    void Update()
    {
        if(numberOfSpawns > 0)
        {
            Spawning();
        }
    }

    private void Spawning()
    {
        GameObject spawnling = Instantiate(spawnlingPrefab, transform.position, transform.rotation);
        spawnling.transform.parent = transform;
    }

    public void AddSpawn(int spawnling)
    {
        numberOfSpawns += spawnling;
    }
}
