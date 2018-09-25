using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 1.0f;

    private WaveConfig currentWave;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnAllWaves());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i < waveConfigs.Count; i++)
        {
            currentWave = waveConfigs[i];
            StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    public WaveConfig GetCurrentWave()
    {
        return this.currentWave;
    }

}
