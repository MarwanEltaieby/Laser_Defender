using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfigSO waveConfig;

    private void Start() {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO GetWaveConfig() {
        return waveConfig;
    }

    private IEnumerator SpawnEnemies()
    {
        do {
            foreach (WaveConfigSO waveConfig in waveConfigs) {
                this.waveConfig = waveConfig;
                for (int i = 0; i < waveConfig.GetEnemyCount(); i++) {
                    Instantiate(waveConfig.GetEnemyPrefab(i), 
                                waveConfig.GetStartingWaypoint().position, 
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSecondsRealtime(waveConfig.GetRandomSpawnTime());
                }
            yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
