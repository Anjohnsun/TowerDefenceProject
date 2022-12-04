using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : BasicTrap
{
    public override void BuildTrap()
    {
        transform.position = transform.position - new Vector3(0, 0.2f, 0);
        GetComponent<Collider>().isTrigger = false;
        //rebake NavMesh
    }
}
