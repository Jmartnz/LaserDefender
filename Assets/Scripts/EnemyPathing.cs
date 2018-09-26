using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    private List<Transform> waypoints;
    private float moveSpeed = 4.0f;
    private int index = 0;

	// Use this for initialization
	void Start () {
        transform.position = waypoints[index].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (index <= waypoints.Count - 1)
        {
            Vector2 currentPosition = transform.position;
            Vector2 waypointPosition = waypoints[index].transform.position;
            transform.position = Vector2.MoveTowards(currentPosition, waypointPosition, moveSpeed * Time.deltaTime);
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

    public void SetWaypoints(List<Transform> waypoints)
    {
        this.waypoints = waypoints;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

}
