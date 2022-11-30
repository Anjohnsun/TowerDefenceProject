using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

interface IMonster : IDamagable, IMovable, IAttackable
{
    void habbit(int viewArea, float viewsDistance, NavMeshAgent agent)
    {

    }
    void refreshTarget(Vector3 target)
    {

    }

}
