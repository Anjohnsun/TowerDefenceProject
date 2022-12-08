using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveMonstr : BasicMonster
{
    [SerializeField] private int _dealDamage;
    [SerializeField] private float _attackRange = 1;
    private float _distanceToPlayer;
    private void Start()
    {
        MakePath();
        Agent.radius = Random.Range(1, 3);
    }

    void Update()
    {
       _distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position); ;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == 9)
        {
            StartCoroutine(MakePlayerTarget());
            if (_distanceToPlayer <= _attackRange)
            {

            }
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
