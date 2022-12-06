using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] PlayerView _playerView;
    [SerializeField] TrapBuilder _trapBuilder;
    [SerializeField] FirstPersonController _fPController;
    [SerializeField] InputManager _inputManager;
    [SerializeField] int _startCoinAmount;
    private GameStateManager _gameStateManager;
    private PlayerController _playerController;

    
    private void Start()
    {
        _gameStateManager = new GameStateManager();
        _gameStateManager.SetState(GameState.Gameplay);
        _playerController = new PlayerController(_trapBuilder, _playerView, _startCoinAmount,_fPController, _gameStateManager, _inputManager);

    }
}
