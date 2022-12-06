using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicTrap : MonoBehaviour
{
    [SerializeField] protected LayerMask _buildSurface;
    [SerializeField] protected Renderer _renderer;

    protected bool _canBeGrounded = true;
    protected bool _isGrounded = false;
    protected int _collisionCount;

    public LayerMask BuildSurface { get => _buildSurface; set => _buildSurface = value; }
    public bool CanBeGrounded => _canBeGrounded;


    protected virtual void OnTriggerEnter(Collider other)
    {
            if (!_isGrounded && (other.GetComponent<BasicTrap>() == null || other.GetComponent<BasicTrap>().BuildSurface == _buildSurface))
            {
                _canBeGrounded = false;
                _renderer.material.color = new Color(1, 0, 0, 0.5f);
                _collisionCount++;
            }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (!_isGrounded && (other.GetComponent<BasicTrap>() == null || other.GetComponent<BasicTrap>().BuildSurface == _buildSurface))
        {
            _collisionCount--;
            if (_collisionCount == 0)
            {
                _canBeGrounded = true;
                _renderer.material.color = new Color(0, 1, 0, 1f);
            }
        }
    }

    public virtual void BuildTrap()
    {
        //анима установки
        _isGrounded = true;
        _renderer.material.color = Color.black;
    }

    protected virtual void OnGameStateChanged(GameState newGameState) 
    { 
    
    }
}
