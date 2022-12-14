using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private TrapBuilder _trapBuilder;
    private PlayerView _playerVeiw;
    private FirstPersonController _fPController;
    private GameStateManager _gSManager;


    public PlayerController(TrapBuilder trapBuilder, PlayerView playerVeiw, int startCoinAmount,
        FirstPersonController fPController, GameStateManager gSManager, InputManager inputManager)
    {
        _trapBuilder = trapBuilder;
        _playerVeiw = playerVeiw;
        _fPController = fPController;
        _gSManager = gSManager;
        _gSManager.OnGameStateChanged += OnGameStateChanged;
        inputManager.OnInventorySlotClicked.AddListener(OnInventorySlotClicked);
        inputManager.OnMouseClicked.AddListener(OnMouseLeftClicked);
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Gameplay:
                _fPController.enabled = true;
                break;
            case GameState.Paused:
                _fPController.enabled = false;
                break;
        }
    }

    private void OnInventorySlotClicked(KeyCode key)
    {
        if (key == KeyCode.Alpha1)
        {
            //??????????? ?? ?????(????????, ???????? ?????? ????? ? ??????????? ?????)
            _trapBuilder.enabled = false;
        }
        else
        {
            _trapBuilder.enabled = true;
            _trapBuilder.StartPlacingTrap(key);
        }
    }

    private void OnMouseLeftClicked()
    {
        _trapBuilder.TryBuildTrap();
    }
}
