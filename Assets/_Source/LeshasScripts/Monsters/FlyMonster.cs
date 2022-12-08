using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMonster : BasicMonster
{

   
    void Start()
    {
        MakePath();
        Agent.radius = Random.Range(1, 3);
    }
}
