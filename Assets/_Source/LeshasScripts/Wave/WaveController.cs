using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveController : MonoBehaviour
{
    [SerializeField] private Dictionary<int, string> _enemys = new Dictionary<int, string>();
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _waveOption;
    [SerializeField] private Vector3 _enemySpawn;
    [SerializeField] private WaveSO FirstWaveSO;
    void Start()
    {
       // _enemys.Add(FirstWaveSO._agressiveAmount, FirstWaveSO._agressiveName);
        _enemys.Add(FirstWaveSO._basicAmount , FirstWaveSO._basicName );
        // _enemys.Add(FirstWaveSO._flyAmount , FirstWaveSO._flyName );
        // _enemys.Add(FirstWaveSO._shootAmount , FirstWaveSO._shootName );
        for (int i = 0; i < _enemys.Count; i++)
        {
            for (int j = 0; j < FirstWaveSO._basicAmount; j++)
            {
                Instantiate(_enemyPrefab, _enemySpawn, Quaternion.identity);
            }

        }

    }

    
    void Update()
    {
        
    }
}
