using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWave")]
public class WaveSO : ScriptableObject
{
   

    [SerializeField] public int _basicAmount;
    [SerializeField] public string _basicName;

    [SerializeField] public int _flyAmount;
    [SerializeField] public string _flyName;

    [SerializeField] public int _shootAmount;
    [SerializeField] public string _shootName;

    [SerializeField] public int _agressiveAmount;
    [SerializeField] public string _agressiveName;
}
