using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] Transform spawnLocation = null;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Grow()
    {
        animator.SetTrigger("grow");
    }

    public void Spawn(GameObject prefab)
    {
        Instantiate(prefab, spawnLocation.position, prefab.transform.rotation);
    }
}
