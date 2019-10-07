using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    [SerializeField] UnityEvent birdFly = null;
    [SerializeField] UnityEvent birdAttack = null;

    EnemyAI birdBrain;

    private void Awake()
    {
        birdBrain = GetComponent<EnemyAI>();
        NoPeck();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Poison>().isActiveAndEnabled)
        {
            return;
        }
        else
        {
            birdAttack.Invoke();
        }
    }

    public void NoPeck()
    {
        birdBrain.DoDamage();
        birdFly.Invoke();
    }
}
