using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
     [SerializeField] private int _startGatePoints;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            _startGatePoints--;
            Destroy(other.gameObject);
        }
    }
}
