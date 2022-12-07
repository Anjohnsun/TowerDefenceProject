using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    public GameState CurrentGameState { get; private set; } = GameState.Gameplay;

    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    public GameStateManager(InputManager inputManager)
    {
        inputManager.OnEscapeClicked.AddListener(OnEscapeClicked);
    }

    public void SetState(GameState newGameState)
    {
        if (newGameState == CurrentGameState)
            return;

        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }

    private void OnEscapeClicked()
    {
        SetState(CurrentGameState == GameState.Gameplay ? GameState.Paused : GameState.Gameplay);
    }
}
