using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.DeviceSimulation;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
     WaveConfigSO currentWave;
    [SerializeField] WaveConfigSO[] waveConfigs;
    [SerializeField] float timeBetweenWaves=1f;
    [SerializeField] bool isLooping=true;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        do
            {
                foreach(WaveConfigSO wave in waveConfigs)
            {
                currentWave=wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity,transform);
                yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }while(isLooping);
        
        
        
    }
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
