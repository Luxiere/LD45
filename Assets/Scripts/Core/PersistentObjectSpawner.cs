using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject presistentObjectPrefab = null;
    static bool hasSpawned;

    private void Awake()
    {
        if (hasSpawned) return;
        SpawnPersistentObject();
        hasSpawned = true;
    }

    private void SpawnPersistentObject()
    {
        GameObject spawned = Instantiate(presistentObjectPrefab);
        DontDestroyOnLoad(spawned);
    }
}
