using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float moveSpeed = 2.0f;

    public GameObject GetEnemyPrefab() { return this.enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();
        foreach (Transform t in pathPrefab.transform)
        {
            waypoints.Add(t);
        }
        return waypoints;
    }

    public float GetTimeBetweenSpawns() { return this.timeBetweenSpawns; }

    public int GetNumberOfEnemies() { return this.numberOfEnemies; }

    public float GetMoveSpeed() { return this.moveSpeed; }

}
