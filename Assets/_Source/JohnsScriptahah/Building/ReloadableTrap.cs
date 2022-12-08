using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReloadableTrap : BasicTrap, IAttackable
{
    [SerializeField] protected float _reloadTime;
    protected float _reloadProgress;
    protected bool _isCharged;

    protected int _damage;

    protected List<BasicMonster> _monstersInArea = new List<BasicMonster>();
    protected GameState _currentGameState = GameState.Gameplay;

    public int Damage => _damage;

    private void Update()
    {
        if (!_isCharged)
        {
            _reloadProgress += Time.deltaTime;
            if(_reloadProgress > _reloadTime)
            {
                _isCharged = true;
                _reloadProgress = 0;
                if(_monstersInArea.Count > 0)
                {
                    ActivateTrap();
                }
            }
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (_isGrounded)
        {
            var enemy = other.GetComponent<BasicMonster>();
            if (enemy != null)
            {
                _monstersInArea.Add(enemy);
                if (_isCharged)
                {
                    ActivateTrap();
                }
            } 
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    public override void OnGameStateChanged(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Gameplay:
                _currentGameState = GameState.Gameplay;
                break;
            case GameState.Paused:
                _currentGameState = GameState.Paused;
                break;
        }
    }

    public override void BuildTrap()
    {
        base.BuildTrap();
        _isCharged = true;
    }

    protected virtual void ActivateTrap()
    {
        StartCoroutine(ActivateTrapCoroutine());
    }

    protected virtual IEnumerator ActivateTrapCoroutine()
    {
        return null;
    }
}
