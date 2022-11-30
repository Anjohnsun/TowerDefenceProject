using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BasicMonster : MonoBehaviour, IMonster
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Vector3 _trarget;
    [SerializeField] private GameObject player;
    [SerializeField] private int _hp;
    [SerializeField] private int _dealDamage;
    
    private void Start()
    {
        _agent.SetDestination(_trarget);
    }
    void refreshTarget(Vector3 target)
    {
       /* if()
        {
            _agent.SetDestination(player.transform.position);
        }
         if()
        {
            _agent.SetDestination(_trarget);
        } */
    }

    void getDamage(int damage)
    {


    }
    void deathChecker()
    {
        if (_hp <= 0)
        {
            WaveController.DEATHS++;
            Destroy(gameObject);

        }
    }
}
