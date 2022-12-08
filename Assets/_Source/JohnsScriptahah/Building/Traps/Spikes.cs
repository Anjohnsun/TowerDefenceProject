using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : ReloadableTrap
{
    protected override void ActivateTrap()
    {
        base.ActivateTrap();

        foreach (BasicMonster monster in _monstersInArea)
        {
            monster.GetDamage(Damage);
        }
    }

    protected override IEnumerator ActivateTrapCoroutine()
    {
        //animations
        yield return null;
    }

}
