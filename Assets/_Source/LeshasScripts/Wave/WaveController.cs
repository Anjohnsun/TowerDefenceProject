using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveController : MonoBehaviour
{
    [SerializeField] private Dictionary<int, string> _enemys = new Dictionary<int, string>();
    private List<GameObject> _spawnedEnemys = new List<GameObject>();
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _waveOption;
    [SerializeField] private Vector3 _enemySpawn;
    [SerializeField] private WaveSO FirstWaveSO;
    [SerializeField] private WaveSO SecondWaveSO;
    [SerializeField] private WaveSO ThirdWaveSO;
    public static int DEATHS;
    private int _waveNumber = 1;
    void Start()
    {
       // _enemys.Add(FirstWaveSO._agressiveAmount, FirstWaveSO._agressiveName);
        _enemys.Add(FirstWaveSO._basicAmount , FirstWaveSO._basicName );
        // _enemys.Add(FirstWaveSO._flyAmount , FirstWaveSO._flyName );
        // _enemys.Add(FirstWaveSO._shootAmount , FirstWaveSO._shootName );

        switch (_waveNumber)
        {
            case 1 :
                for (int i = 0; i < _enemys.Count; i++)
                {
                    for (int j = 0; j < FirstWaveSO._basicAmount; j++)
                    {
                        Instantiate(_enemyPrefab, _enemySpawn, Quaternion.identity);
                    }
                    
                }
                
                break;
            case 2 :
                for (int i = 0; i < _enemys.Count; i++)
                {
                    for (int j = 0; j < SecondWaveSO._basicAmount; j++)
                    {
                        Instantiate(_enemyPrefab, _enemySpawn, Quaternion.identity);
                    }

                }
                
                break;
            case 3:
                for (int i = 0; i < _enemys.Count; i++)
                {
                    for (int j = 0; j < ThirdWaveSO._basicAmount; j++)
                    {
                        Instantiate(_enemyPrefab, _enemySpawn, Quaternion.identity);
                    }

                }
                break;
        }

       
    }
    private void Update()
    {
        if(DEATHS >= FirstWaveSO._basicAmount && DEATHS < SecondWaveSO._basicAmount)
        {
            _waveNumber++;
            DEATHS = 0;
        } else if (DEATHS >= SecondWaveSO._basicAmount && DEATHS < ThirdWaveSO._basicAmount)
        {
            _waveNumber++;
            DEATHS = 0;
        } 
    }
}
