using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlades : BasicTrap, IReloadableTrap, IAttackable
{
    [SerializeField] private float _reloadTime;
    private float _reloadProgress;
    private bool _isCharged = false;
    private List<BasicMonster> _monstersInArea = new List<BasicMonster>();

    private GameState _currentGameState = GameState.Gameplay;

    public float ReloadTime => _reloadTime;

    public override void BuildTrap()
    {
        base.BuildTrap();
        _isCharged = true;
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
        _monstersInArea.Remove(other.GetComponent<BasicMonster>());
    }

    private void Update()
    {
        if(_currentGameState == GameState.Gameplay)
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

    IEnumerator ActivateTrapCoroutine()
    {
        yield return null;
    }

    protected override void OnGameStateChanged(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Gameplay:
                _currentGameState = GameState.Paused;
                break;
            case GameState.Paused:
                _currentGameState = GameState.Gameplay;
                break;
        }
    }
}