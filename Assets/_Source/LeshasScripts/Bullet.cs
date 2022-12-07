using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _dealDamage;

    private void Start()
    {
        Destroy(gameObject, 5);
    } 
}
