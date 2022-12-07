using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReloadableTrap
{
    float ReloadTime { get; }
    GameState CurrentGameState { get; }
    void ActivateTrap();
}
