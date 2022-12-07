using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

interface IMonster : IDamagable, IAttackable
{
    public NavMeshAgent NavMeshAgent { get;  }

    void RefreshTarget(Vector3 target)
    {

    }

}
