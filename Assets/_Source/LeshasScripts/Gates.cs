using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : IDamagable
{
    [SerializeField] private int _hp;

    public int Health => throw new System.NotImplementedException();

    void CheakDeath(int _hp)
    {
        if (_hp <= 0)
        {

            

        }
    }
    
}
