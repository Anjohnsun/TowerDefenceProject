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

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == 9)
        {
            StartCoroutine(MakePlayerTarget());
            Agent.radius = Random.Range(1, 3);
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
