using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 1.0f;
    [SerializeField] private bool looping = false;
    [SerializeField] private bool active = true;

    // Use this for initialization
    IEnumerator Start()
    {
        if (active)
        {
            do
            {
                yield return StartCoroutine(SpawnAllWaves());
            }
            while (looping);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig waveConfig in waveConfigs)
        {
            // yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfig));
            // Use timeBetweenWaves as delay between each wave
            StartCoroutine(SpawnAllEnemiesInWave(waveConfig));
            yield return new WaitForSeconds(timeBetweenWaves);
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
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

}
