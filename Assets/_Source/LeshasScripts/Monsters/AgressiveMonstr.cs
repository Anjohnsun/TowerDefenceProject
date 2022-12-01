using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveMonstr : BasicMonster
{
    [SerializeField] private float _distanceToPlayer;
    
    [SerializeField] private float _attackTrigerRadius;

    void Start()
    {
        
    }

    void Update()
    {
        _distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);

        if (_distanceToPlayer <= _attackTrigerRadius)
        {
            playerTargetNow();
        } else if(_distanceToPlayer >= _attackTrigerRadius)
        {
            gatesTargetAgain();
        }
    }
}
