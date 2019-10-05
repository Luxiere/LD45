using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "Game/Enemy/Stat")]
public class EnemyStats : ScriptableObject
{
    public int damage = 20;
    public float speed = 5f;

    public void TakeDamage()
    {
        WaterBar water = GameObject.FindWithTag("Player").GetComponent<WaterBar>();
        water.LoseWater(damage);
    }

}
