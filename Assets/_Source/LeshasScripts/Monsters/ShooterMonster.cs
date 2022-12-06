using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMonster : BasicMonster
{
    [SerializeField] private float _distanceToPlayer;

    [SerializeField] private float _attackTrigerRadius;
    [SerializeField] private GameObject _bulletPref;
    private float reloadTime = 0;
    void Start()
    {
        GatesTargetAgain();
    }

   
    void Update()
    {
            
        _distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
        reloadTime -= Time.deltaTime;
        if (_distanceToPlayer <= _attackTrigerRadius)
        {
            if (reloadTime <= 0 )
            {
                _agent.speed = 0;
                Shooting();
                
            }
            
            
        }
        else if (_distanceToPlayer >= _attackTrigerRadius)
        {
            _agent.speed = 3;
        }
    }
    void Shooting()
    {
        Rigidbody rb = Instantiate(_bulletPref, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

        reloadTime = 3;
       
    }
   
}
