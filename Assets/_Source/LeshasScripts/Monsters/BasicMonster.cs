using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BasicMonster : MonoBehaviour, IMonster
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Vector3 _trarget;
    private void Start()
    {
        _agent.SetDestination(_trarget);
    }
    void refreshTarget(Vector3 target)
    {

    }
}
