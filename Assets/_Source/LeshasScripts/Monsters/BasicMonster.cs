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
    [SerializeField] private float _timeBetweenAttacks;
    [SerializeField] private int cost;
    public float _actualTimeBetweenAttacks;
    

    public NavMeshAgent NavMeshAgent => throw new System.NotImplementedException();

    public int Health => throw new System.NotImplementedException();

    public int Damage => throw new System.NotImplementedException();


    private void Start()
    {
        MakePath();
        _actualTimeBetweenAttacks = _timeBetweenAttacks;
        
        
    }
    public void MakePath()
    {
        _gates = GameObject.FindGameObjectWithTag("Gate");
        Vector3 Target = _gates.transform.position;
        RefreshTarget(Target);
    }
    private void Update()
    {
        _actualTimeBetweenAttacks -= Time.deltaTime;
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
            Destroy(gameObject);

        }
    }
    
}
