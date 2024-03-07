using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config" ,fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform path;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public float GetRandomSpawnTime() {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

    public float GetMovementSpeed() {
        return movementSpeed;
    }

    public Transform GetStartingWaypoint() {
        return path.GetChild(0);
    }

    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        return enemyPrefabs[index];
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform waypoint in path) {
            waypoints.Add(waypoint);
        }
        return waypoints;
    }
}
