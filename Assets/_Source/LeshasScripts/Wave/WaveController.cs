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
    [SerializeField] private Vector3 _firstEnemySpawn;
    [SerializeField] private Vector3 _secondEnemySpawn;
    private List<Vector3> _spawns = new List<Vector3>();
    /*
     * private Dictionary<BasicMonster, count> EnemiesCount= new Dictionary<BasicMonster, count>;
     * 
     */

    void Start()
    {
        
        _spawns.Add(_firstEnemySpawn);
        _spawns.Add(_secondEnemySpawn);
        StartCoroutine(SpawnWaveCoroutine());
        /*
         * EnemiesCount.add();//добавить все кол-ва врагов в словарь
         */
    }
    
    private IEnumerator SpawnWaveCoroutine()
    {
        for (int i = 0; i < _waves.Count; i++)
        {
            

            for (int m = 0; m < _waves[i].basicAmount; m++)
            {
                
                Instantiate(_enemyPrefab, _spawns[Random.Range(0, _spawns.Count)], Quaternion.identity);
            }
            for (int j = 0; j < _waves[i].flyAmount; j++)
            {
                Instantiate(_enemyFlyPrefab, _spawns[Random.Range(0, _spawns.Count)], Quaternion.identity);
            }
            for (int k = 0; k < _waves[i].agressiveAmount; k++)
            {
                Instantiate(_enemyAgrrPrefab, _spawns[Random.Range(0, _spawns.Count)], Quaternion.identity);
            }
            for (int s = 0; s < _waves[i].shootAmount; s++)
            {
                Instantiate(_enemyShootPrefab, _spawns[Random.Range(0, _spawns.Count)], Quaternion.identity);
            }
            yield return new WaitForSeconds(_waves[i].timeBetweenWaves);
        }
        yield return null;
        

        /*
         * ѕока не все значени€ в словаре == 0, ¬ыбрать рандомный тип и заспавнить, после случайной задержки N секунд повторить.
         */
    }
}
