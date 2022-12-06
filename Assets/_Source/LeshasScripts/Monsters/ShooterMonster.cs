using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMonster : BasicMonster
{
    
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private float _bulletSpeed = 32f;
    private float reloadTime = 0;
    void Start()
    {
        RefreshTarget(Trarget);
    }

   
    void Update()
    {

        reloadTime -= Time.deltaTime;
        
    }
    void Shoot()
    {
        if(reloadTime <= 0)
        {

        }
        Rigidbody rb = Instantiate(_bulletPref, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);

        reloadTime = 3;
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdas");
        Agent.speed = 0;
        Shoot();
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("asdas");
        Agent.speed = 3;
    }
}
