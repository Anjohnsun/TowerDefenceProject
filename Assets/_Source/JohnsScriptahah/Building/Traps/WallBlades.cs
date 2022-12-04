using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlades : BasicTrap, IReloadableTrap, IAttackable
{
    [SerializeField] private float _reloadTime;
    private float _reloadProgress;
    private bool _isCharged = false;
    private List<BasicMonster> _monstersInArea = new List<BasicMonster>();

    public float ReloadTime => _reloadTime;

    public override void BuildTrap()
    {
        base.BuildTrap();
        _isCharged = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isGrounded)
        {
            var enemy = other.GetComponent<BasicMonster>();
            if (enemy != null)
            {
                _monstersInArea.Add(enemy);
                if (_isCharged)
                {

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _monstersInArea.Remove(other.GetComponent<BasicMonster>());
    }

    private void Update()
    {
        if (!_isCharged)
        {
            _reloadProgress += Time.deltaTime;
            if (_reloadProgress >= _reloadTime)
            {
                _isCharged = true;
                _reloadProgress = 0;
            }
        }
    }

    public void ActivateTrap()
    {
        _isCharged = false;
        foreach (BasicMonster monster in _monstersInArea)
        {
            //affect monster
        }
        StartCoroutine(ActivateTrapCoroutine());
    }

    public void ReloadTrap()
    {
        _isCharged = false;
    }

    IEnumerator ActivateTrapCoroutine()
    {
        yield return null;
    }
}
