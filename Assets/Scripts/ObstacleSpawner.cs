using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    [SerializeField] private float spawnTimeMin = 2f;
    [SerializeField] private float spawnTimeMax = 5f;
    [SerializeField] private float obstacleSpeed = 3f;

    private float timeUntilObstacleSpawn;

    public List<GameObject> activeObstacles;

    [SerializeField] private GameObject stageStart;
 

    private Transform lastLavelPartTransform;
    private void Start()
    {

        StartSpawn();
    }
    private void Update()
    {
        if(GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }
        
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            obstacleSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            timeUntilObstacleSpawn = 0f;
        }
    }
    private void StartSpawn()
    {
        if(stageStart != null)
        {
            Rigidbody2D obstacleRB = stageStart.GetComponent<Rigidbody2D>();
            //obstacleRB.velocity = new Vector2(-1 * obstacleSpeed, 0); long form
            obstacleRB.velocity = Vector2.left * obstacleSpeed;
            activeObstacles.Add(stageStart);
        }
        
        
    }
    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);


        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        //obstacleRB.velocity = new Vector2(-1 * obstacleSpeed, 0); long form
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
        activeObstacles.Add(spawnedObstacle);
    }

    public void PauseObstacles()
    {
        foreach (GameObject obstacle in activeObstacles)
        {
            Rigidbody2D obstacleRB = obstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * 0f;
        }
    }

    public void ResumeObstacles()
    {
        foreach (GameObject obstacle in activeObstacles)
        {
            Rigidbody2D obstacleRB = obstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * obstacleSpeed;
        }
    }

}
