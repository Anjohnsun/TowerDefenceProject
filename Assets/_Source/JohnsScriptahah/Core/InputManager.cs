using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private List<KeyCode> _inventoryKeys;

    public UnityEvent<KeyCode> OnInventorySlotClicked = new UnityEvent<KeyCode>();
    public UnityEvent OnMouseClicked = new UnityEvent();
    public UnityEvent OnEscapeClicked = new UnityEvent();
    [SerializeField] private GameState _currentGameState = GameState.Gameplay;

    private void Update()
    {
        if (_currentGameState == GameState.Gameplay)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnMouseClicked.Invoke();
            }

            foreach (KeyCode key in _inventoryKeys)
            {
                if (Input.GetKeyDown(key))
                    OnInventorySlotClicked.Invoke(key);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscapeClicked.Invoke();
        }

    }

    public void Construct(GameStateManager gSManager)
    {
        gSManager.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
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
