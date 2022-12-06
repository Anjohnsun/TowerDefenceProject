using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BasicMonster : MonoBehaviour, IMonster
{
    [SerializeField] public NavMeshAgent Agent;
    [SerializeField] public Vector3 Trarget;
    [SerializeField] public GameObject player;
    [SerializeField] private int _hp;
    [SerializeField] private int _dealDamage;

    public NavMeshAgent NavMeshAgent => throw new System.NotImplementedException();

    public int Health => throw new System.NotImplementedException();

    public int Damage => throw new System.NotImplementedException();

    private void Start()
    {
        Agent.SetDestination(Trarget);
    }
    public void RefreshTarget(Vector3 target)
    {
        Agent.SetDestination(target);
           
    }
   
    void damageGates()
    {
       
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
