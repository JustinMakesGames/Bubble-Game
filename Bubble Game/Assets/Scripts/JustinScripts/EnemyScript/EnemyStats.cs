using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyStats", menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public int health;
    public float walkSpeed;
    public float bulletSpeed;
    public int minWaveSpawnMoment;
}
