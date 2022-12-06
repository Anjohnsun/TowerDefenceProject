using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : IDamagable
{
    [SerializeField] public int GatesHp;

    public int Health => throw new System.NotImplementedException();
    
    void CheakDeath(int _hp)
    {
        if (_hp <= 0)
        {

            

        }
    }
    
    
}
