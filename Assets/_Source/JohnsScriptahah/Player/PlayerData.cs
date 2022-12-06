using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private int _maxHealth;
    private int _currentHealth;

    private int _coinAmount;

    public PlayerData(int maxHealth, int currentHealth, int coinAmount)
    {
        _maxHealth = maxHealth;
        _currentHealth = currentHealth;
        _coinAmount = coinAmount;
    }
}
