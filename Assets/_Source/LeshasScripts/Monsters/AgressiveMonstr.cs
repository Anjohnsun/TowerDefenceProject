using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveMonstr : BasicMonster
{

    private void Start()
    {
        MakePath();
    }

    void Update()
    {

        _actualTimeBetweenAttacks -= Time.deltaTime;


    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == 9)
        {
            StartCoroutine(MakePlayerTarget());
        }
       


    }
    private IEnumerator MakePlayerTarget()
    {

        RefreshTarget(player.transform.position);
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(MakePlayerTarget());

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            RefreshTarget(Trarget);
            StopAllCoroutines();
        }
       
    }

}
