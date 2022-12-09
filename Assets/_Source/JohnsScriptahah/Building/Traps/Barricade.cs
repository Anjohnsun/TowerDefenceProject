using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Barricade : BasicTrap
{
    public override void BuildTrap()
    {
        base.BuildTrap();
        transform.position = transform.position - new Vector3(0, 0.2f, 0);
        GetComponent<Collider>().isTrigger = false;
        var navMesh = GameObject.FindGameObjectWithTag("NavMeshSurface");
        NavMeshSurface navMeshSurface = navMesh.GetComponent<NavMeshSurface>();
        navMeshSurface.BuildNavMesh();

        if (navMesh == null)
            Debug.Log("navMesh");
    }

    public override void OnGameStateChanged(GameState newGameState)
    {
    }
}
