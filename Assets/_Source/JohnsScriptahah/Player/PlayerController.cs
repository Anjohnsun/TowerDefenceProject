using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private TrapBuilder _trapBuilder;
    private PlayerView _playerVeiw;
    private PlayerData _playerData;
    private FirstPersonController _fPController;
    private GameStateManager _gSManager;

    public PlayerController(TrapBuilder trapBuilder, PlayerView playerVeiw, int startCoinAmount, 
        FirstPersonController fPController, GameStateManager gSManager, InputManager inputManager)
    {
        _trapBuilder = trapBuilder;
        _playerVeiw = playerVeiw;
        _playerData = new PlayerData(100, 100, startCoinAmount);
        _fPController = fPController;
        _gSManager = gSManager;
        _gSManager.OnGameStateChanged += OnGameStateChanged;
        inputManager.OnInventorySlotClicked.AddListener(OnInventorySlotClicked);
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
        if(key == KeyCode.Alpha1)
        {
            //переключить на пушку(вероятно, включить объект пушка с компонентом пушка)
            _trapBuilder.enabled = false;
        }
        _trapBuilder.StartPlacingTrap(key);
    }

    //обработка нажатий клавиш инвентарая, Escape, мыши
}
