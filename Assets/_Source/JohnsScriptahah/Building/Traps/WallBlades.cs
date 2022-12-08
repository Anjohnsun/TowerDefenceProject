using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlades : ReloadableTrap
{

    protected override void ActivateTrap()
    {
        _isCharged = false;
        foreach (BasicMonster monster in _monstersInArea)
        {
            monster.GetDamage(Damage);
        }
        StartCoroutine(ActivateTrapCoroutine());
    }

    protected override IEnumerator ActivateTrapCoroutine()
    {
        //animations
        yield return null;
    }
}
