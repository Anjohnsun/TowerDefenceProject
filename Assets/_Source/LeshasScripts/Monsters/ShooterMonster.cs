using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMonster : BasicMonster
{
    
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private float _bulletSpeed = 32f;
    private float reloadTime = 0;
    private bool _playerInColider = false;
    void Start()
    {
        RefreshTarget(Trarget);
    }

   
    void Update()
    {

        reloadTime -= Time.deltaTime;
        if (_playerInColider == true)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if(reloadTime <= 0)
        {
            Rigidbody rb = Instantiate(_bulletPref, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
            reloadTime = 3;
        }  
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Agent.speed = 0;
            _playerInColider = true;
        }  
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("asdasd");
            _playerInColider = false;
            Agent.speed = 3;
        }
        
    }
}
