using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : BasicTrap, IReloadableTrap, IAttackable
{
    [SerializeField] private float _reloadTime;
    private float _reloadProgress;
    [SerializeField] private bool _isCharged = false;
    [SerializeField] int _damage;
    private List<BasicMonster> _monstersInArea = new List<BasicMonster>();
    private GameState _currentGameState = GameState.Gameplay;

    public float ReloadTime => _reloadTime;

    public int Damage => _damage;

    public GameState CurrentGameState => _currentGameState;

    public override void BuildTrap()
    {
        base.BuildTrap();
        transform.position = transform.position - new Vector3(0, 0.2f, 0);
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
                    //affect monsters
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
            monster.GetDamage(Damage);
        }
        StartCoroutine(ActivateTrapCoroutine());
    }

    IEnumerator ActivateTrapCoroutine()
    {
        //animations
        yield return null;
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
}
