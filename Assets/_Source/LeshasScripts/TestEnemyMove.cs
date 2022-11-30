using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TestEnemyMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemy;
    [SerializeField] private Transform gates;
    void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
        _enemy.SetDestination(gates.position);
    }

    
    void Update()
    {

    }
}
