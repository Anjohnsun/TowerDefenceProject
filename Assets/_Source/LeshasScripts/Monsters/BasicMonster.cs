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
    [SerializeField] private GameObject _gates;
    

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
   

    public void GetDamage(int damage, int health)
    {

        health -= damage;
        CheckDeath(health);
    }
    void CheckDeath(int health)
    {
        if (health <= 0)
        {
            
            Destroy(gameObject);

        }
    }
}
