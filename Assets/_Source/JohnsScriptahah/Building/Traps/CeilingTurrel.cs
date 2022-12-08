using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTurrel : ReloadableTrap
{
    [SerializeField] private Vector3 _bulletStartPosition;
    protected override void ActivateTrap()
    {
        _isCharged = false;
        
        StartCoroutine(ActivateTrapCoroutine());
    }
    protected override IEnumerator ActivateTrapCoroutine()
    {
        //animations
        yield return null;
    }
}
