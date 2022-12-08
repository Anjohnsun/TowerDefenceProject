using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTurrel : ReloadableTrap
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Collider _zoneCollider;

    protected override void ActivateTrap()
    {
        base.ActivateTrap();

        Debug.Log("shoot");
        _isCharged = false;
        Rigidbody rb = Instantiate(_bulletPrefab, _bulletStartPosition.position, new Quaternion()).GetComponent<Rigidbody>();
        Vector3 targetPosition = _monstersInArea[0].transform.position;
        rb.AddForce((targetPosition - _bulletStartPosition.position)*_bulletSpeed, ForceMode.Impulse);
    }
    protected override IEnumerator ActivateTrapCoroutine()
    {
        //animations
        yield return null;
    }

    public override void BuildTrap()
    {
        base.BuildTrap();
        _zoneCollider.enabled = true;
    }

}
