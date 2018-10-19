using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private List<WaveConfig> waves;

    [Header("Configuration")]
    [SerializeField] private float defaultTimeBetweenWaves = 5.0f;
    [SerializeField] private bool looping = false;
    [SerializeField] private bool inactive = false;

    private WaveConfig currentWave;
    private int spawnedEnemiesCounter = 0;

    // Use this for initialization
    IEnumerator Start()
    {
        if (!inactive)
        {
            do { yield return StartCoroutine(SpawnAllWaves()); }
            while (looping);
        }
	}

    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig wave in waves)
        {
            currentWave = wave;

            if (wave.IsSeparated())
            {
                StartCoroutine(SpawnAllEnemiesInWave(currentWave));
                do { yield return null; }
                while (AreEnemiesLeft());
            }
            else
            {
                StartCoroutine(SpawnAllEnemiesInWave(currentWave));
                yield return new WaitForSeconds(defaultTimeBetweenWaves + currentWave.GetMercyTime());
            }

            ResetSpawnedEnemiesCounter();
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            var enemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            EnemyPathing enemyPathing = enemy.GetComponent<EnemyPathing>();
            enemyPathing.SetWaypoints(waveConfig.GetWaypoints());
            enemyPathing.SetMoveSpeed(waveConfig.GetMoveSpeed());
            spawnedEnemiesCounter++;
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    private bool AreEnemiesLeft()
    {
        bool existEnemiesOnScene = FindObjectsOfType<Enemy>().Length > 0;
        bool existEnemiesToSpawn = spawnedEnemiesCounter < currentWave.GetNumberOfEnemies();
        return existEnemiesOnScene || existEnemiesToSpawn;
    }

    private void ResetSpawnedEnemiesCounter()
    {
        spawnedEnemiesCounter = 0;
    }

}
