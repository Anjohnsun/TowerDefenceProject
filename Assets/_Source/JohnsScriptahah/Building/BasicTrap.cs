using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrap : MonoBehaviour
{
    [SerializeField] private LayerMask _buildSurface;
    [SerializeField] private Renderer _renderer;

    private bool _canBeGrounded = true;
    protected bool _isGrounded = false;
    private int _collisionCount;

    public LayerMask BuildSurface { get => _buildSurface; set => _buildSurface = value; }
    public bool CanBeGrounded => _canBeGrounded;


    private void OnTriggerEnter(Collider other)
    {
            if (!_isGrounded && (other.GetComponent<BasicTrap>() == null || other.GetComponent<BasicTrap>().BuildSurface == _buildSurface))
            {
                _canBeGrounded = false;
                _renderer.material.color = new Color(1, 0, 0, 0.5f);
                _collisionCount++;
            }
    }

    private void OnTriggerExit(Collider other)
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
}
