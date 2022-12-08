using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveMonstr : BasicMonster
{
    [SerializeField] private int _dealDamage;
    [SerializeField] private float _attackRange = 1;
    [SerializeField] private float _attackCoolDawn = 3;
    private float _attckCoolDawnRihtNow;
    private bool _playerNear = false;

    private float _distanceToPlayer;
    private void Start()
    {
        MakePath();
        Agent.radius = Random.Range(1, 3);
        _attckCoolDawnRihtNow = _attackCoolDawn;
    }

    void Update()
    {
       if(_playerNear == true)
       {
            _attckCoolDawnRihtNow--;
            Attack();
       }
    }
    private void Attack()
    {
        _distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        if(_attckCoolDawnRihtNow <= 0 && _distanceToPlayer <= _attackRange)
        {

            _attckCoolDawnRihtNow = 3;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == 9)
        {
            StartCoroutine(MakePlayerTarget());
            _playerNear = true;
        }
         
    }
    private IEnumerator MakePlayerTarget()
    {

        RefreshTarget(Player.transform.position);
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(MakePlayerTarget());

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            RefreshTarget(Target);
            StopAllCoroutines();
        }
       
    }

}
