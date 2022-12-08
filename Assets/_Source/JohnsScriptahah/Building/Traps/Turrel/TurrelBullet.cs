using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask[] _ignoreLayers;
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<BasicMonster>();
        if(enemy != null)
        {
            enemy.GetDamage(_damage);
        }
        foreach (LayerMask layer in _ignoreLayers)
        {
            if (layer == other.gameObject.layer)
                return;
        }
        Destroy(gameObject);
    }
}
