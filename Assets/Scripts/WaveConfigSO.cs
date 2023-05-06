using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float timeBetweenEnemySpawn = 1.0f;
    [SerializeField] float spawnTimeVariance = 0.0f;
    [SerializeField] float minSpawnTime = 0.2f;

    public Transform GetStartingWaypoint() {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();

        foreach(Transform child in pathPrefab) {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public int GetEnemiesCount() {
        return enemies.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        return enemies[index];
    }

    public float GetRandomSpawnTime() {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - spawnTimeVariance,
                                        timeBetweenEnemySpawn + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
