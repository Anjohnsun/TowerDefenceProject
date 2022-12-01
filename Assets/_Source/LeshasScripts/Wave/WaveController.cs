using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveController : MonoBehaviour
{

    [SerializeField] private List<WaveSO> _waves = new List<WaveSO>();
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyShootPrefab;
    [SerializeField] private GameObject _enemyFlyPrefab;
    [SerializeField] private GameObject _enemyAgrrPrefab;
    [SerializeField] private GameObject _waveOption;
    [SerializeField] private Vector3 _enemySpawn;
    [SerializeField] private WaveSO FirstWaveSO;
    [SerializeField] private WaveSO SecondWaveSO;
    [SerializeField] private WaveSO ThirdWaveSO;
    
    void Start()
    {
        spawnWave();
    }
    
    private void spawnWave()
    {
        
        for (int i = 0; i < _waves.Count; i++)
        {
            for (int m = 0; m < _waves[i].basicAmount; m++)
            {
                Instantiate(_enemyPrefab, _enemySpawn, Quaternion.identity);
            }
            for (int j = 0; j < _waves[i].flyAmount; j++)
            {
                Instantiate(_enemyFlyPrefab, _enemySpawn, Quaternion.identity);
            }
            for (int k = 0; k < _waves[i].agressiveAmount; k++)
            {
                Instantiate(_enemyAgrrPrefab, _enemySpawn, Quaternion.identity);
            }
            for (int s = 0; s < _waves[i].shootAmount; s++)
            {
                Instantiate(_enemyShootPrefab, _enemySpawn, Quaternion.identity);
            }
        }
    }
}
