using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWave")]
public class WaveSO : ScriptableObject
{
   

    [SerializeField] public int basicAmount;
   

    [SerializeField] public int flyAmount;
   

    [SerializeField] public int shootAmount;
    

    [SerializeField] public int agressiveAmount;

    [SerializeField] public int enemysAmountTotal;

    [SerializeField] public int timeBetweenWaves;
}
