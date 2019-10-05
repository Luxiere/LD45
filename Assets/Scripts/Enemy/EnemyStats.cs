using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : ScriptableObject
{
    [SerializeField] int damage = 20;
    [SerializeField] float speed = 5f;
    [SerializeField] EnemyPathing pathing = null;

    public void TakeDamage()
    {
        WaterBar water = GameObject.FindWithTag("Player").GetComponent<WaterBar>();
        water.LoseWater(damage);
    }

}
