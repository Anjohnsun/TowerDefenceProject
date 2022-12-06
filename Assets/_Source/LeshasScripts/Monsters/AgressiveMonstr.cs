using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveMonstr : BasicMonster
{
        [SerializeField] private float _attackTrigerRadius;

    void Start()
    {
        
    }

    void Update()
    {
        

       
    }
    private void OnTriggerEnter(Collider other)
    {
        RefreshTarget(player.transform.position);
    }
    private void OnTriggerExit(Collider other)
    {
        RefreshTarget(Trarget);
    }
}
