using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart;

    [SerializeField] private GameObject[] levelPrefabs;
    public float levelSpawnTime = 2f;
    [SerializeField] private float spawnTimeMin = 2f;
    [SerializeField] private float spawnTimeMax = 5f;
    [SerializeField] private float levelSpeed = 3f;

    private float timeUntilObstacleSpawn;
    private void Awake()
    {
        
    }
}
