using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{

    [SerializeField] private List<GameObject> allEnemies;
    private List<GameObject> possibleEnemies = new List<GameObject>();
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private int waveNumber;
    private Transform _player;

    [SerializeField] private int enemyAmount;
    [SerializeField] private Bounds arena;
    


    private void Awake()
    {
        StartNewWave();
    }

    public void StartNewWave()
    {
        
        for (int i = 0; i < enemyAmount; i++)
        {
            for (int j = 0; j < allEnemies.Count; j++)
            {
                if (allEnemies[j].GetComponent<EnemyBehaviour>().enemyStats.minWaveSpawnMoment >= waveNumber)
                {
                    possibleEnemies.Add(allEnemies[j]);
                }
            }

            int randomEnemy = Random.Range(0, possibleEnemies.Count);

            GameObject enemyClone = Instantiate(possibleEnemies[randomEnemy]);
            spawnedEnemies.Add(enemyClone);
            possibleEnemies.Clear();
        }

        foreach (GameObject enemy in spawnedEnemies)
        {
            Vector3 position = ReturnEnemyPosition();
            enemy.transform.position = position;
        }


    }

    private Vector3 ReturnEnemyPosition()
    {
        int xPosition = Random.Range(0, 2);
        int zPosition = Random.Range(0, 2);

        xPosition = xPosition == 0 ? 3 : -3;
        zPosition = zPosition == 0 ? 3 : -3;

        Vector3 spawnPosition = new Vector3(_player.position.x + xPosition, _player.position.y, _player.position.z + zPosition);
        return spawnPosition;
    }
}
