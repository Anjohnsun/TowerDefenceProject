using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicMonster : MonoBehaviour, IMonster
{
    [SerializeField] public NavMeshAgent Agent;
    [SerializeField] public Vector3 Target;
    [SerializeField] public GameObject Player;
    [SerializeField] private int _hp;
    [SerializeField] private GameObject _gates;
    [SerializeField] public float Speed;
    [SerializeField] public Animator Anim; 
    [SerializeField] private int cost;
   
    

    public NavMeshAgent NavMeshAgent => throw new System.NotImplementedException();

    public int Health => throw new System.NotImplementedException();

    public int Damage => throw new System.NotImplementedException();


    private void Start()
    {
        MakePath();
        Agent.speed = Speed;
        Agent.radius = Random.Range(1, 3);
        
    }
    public void MakePath()
    {
        _gates = GameObject.FindGameObjectWithTag("Gate");
        Vector3 Target = _gates.transform.position;
        RefreshTarget(Target);
    }
   
    public void RefreshTarget(Vector3 target)
    {
        Agent.SetDestination(target);
           
    }
    
    public void GetDamage(int damage)
    {

        _hp -= damage;
        CheckDeath(_hp);
    }
    void CheckDeath(int health)
    {
        if (health <= 0)
        {
            MoneyManagerSingleton.Instance.AddCoins(cost);
            Agent.speed = 0;
            Anim.Play("Die");
            Destroy(gameObject, 5);

        }
    }
    
}
