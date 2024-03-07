using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    private void Start() {
        waveConfig = FindObjectOfType<EnemySpawner>().GetWaveConfig();
        transform.position = waveConfig.GetStartingWaypoint().position;
        waypoints = waveConfig.GetWaypoints();
    }

    private void Update() {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoints.Count) {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float speed = waveConfig.GetMovementSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
            if (transform.position == targetPosition) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
