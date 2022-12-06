using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReloadableTrap
{
    float ReloadTime { get; }

    void ActivateTrap();
}
