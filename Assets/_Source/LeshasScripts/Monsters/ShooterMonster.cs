using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMonster : BasicMonster
{
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private float _bulletSpeed = 32f;
    private float reloadTime = 0;
    private bool _playerInColider = false;
    
    void Start()
    {
        MakePath();
        Agent.radius = Random.Range(1, 3);
        
    }

   
    void Update()
    {
        Anim.SetFloat("Speed", Agent.speed);
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
            Anim.SetBool("CastSpell", true);
            Rigidbody rb = Instantiate(_bulletPref, _bulletSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
            reloadTime = 1.10f;
            Anim.SetBool("CastSpell", false);
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
