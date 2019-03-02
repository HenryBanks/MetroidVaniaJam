using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    public List<Vector2> spawnPositionsList;

    public static SpawnPositions instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnDrawGizmos()
    {
        foreach(Vector2 spawnPos in spawnPositionsList)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(spawnPos, 0.5f);
        }
    }

}
