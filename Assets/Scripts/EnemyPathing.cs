using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private int index = 0;

	// Use this for initialization
	void Start () {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[index].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (index <= waypoints.Count - 1)
        {
            Vector2 currentPosition = transform.position;
            Vector2 waypointPosition = waypoints[index].transform.position;
            transform.position = Vector2.MoveTowards(currentPosition, waypointPosition, waveConfig.GetMoveSpeed() * Time.deltaTime);
            if (transform.position == waypoints[index].transform.position)
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
