using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BasicMonster : MonoBehaviour, IMonster
{
    [SerializeField] public NavMeshAgent _agent;
    [SerializeField] private Vector3 _trarget;
    [SerializeField] public GameObject _player;
    [SerializeField] private int _hp;
    [SerializeField] private int _dealDamage;
    
    private void Start()
    {
        _agent.SetDestination(_trarget);
    }
    public void PlayerTargetNow()
    {
            _agent.SetDestination(_player.transform.position);
           
    }
    public void GatesTargetAgain()
    {
        _agent.SetDestination(_trarget);
    }

    void GetDamage(int damage)
    {


    }
    void DeathChecker()
    {
        if (_hp <= 0)
        {
            
            Destroy(gameObject);

        }
    }
}
