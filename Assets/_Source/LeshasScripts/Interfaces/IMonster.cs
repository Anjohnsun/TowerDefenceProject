using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

interface IMonster : IDamagable, IMovable, IAttackable
{
    void Habbit(int viewArea, float viewsDistance, NavMeshAgent agent)
    {

    }
    void RefreshTarget(Vector3 target)
    {

    }

}
