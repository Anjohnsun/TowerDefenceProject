using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTurrel : BasicTrap, IReloadableTrap
{
    private GameState _currentGameState = GameState.Gameplay;

    public float ReloadTime => throw new System.NotImplementedException();

    public GameState CurrentGameState => throw new System.NotImplementedException();

    public void ActivateTrap()
    {
        throw new System.NotImplementedException();
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
