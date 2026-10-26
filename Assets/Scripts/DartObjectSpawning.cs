using UnityEngine;

public class DartObjectSpawning : MonoBehaviour
{
    public static DartObjectSpawning instance;
    //declare the variables for prefab and min/maxpositions
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;
    
    //declare variables for spawn timing and count
    public float spawnTimer;
    public float spawnInterval = 2f;
    public float minSpawnInterval = 1f;
    public int spawnedObjectCount;
    public float speed;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed -= Time.deltaTime / 10;
        if (speed < -9)
        {
            speed = -9;
        }
        spawnInterval -= Time.deltaTime / 15;
        if (spawnInterval <= 1)
        {
            spawnInterval = 1;
        }
        spawnTimer += Time.deltaTime; // increase the spawntimer with deltatime
        if (spawnTimer >= spawnInterval) // if the spawntimer is greater than or equal to the spawninterval
        {
            spawnTimer = 0; //reset the spawntimer to 0
            spawnObject(); //call spawnobject function
        }
    }

    private void spawnObject()
    {
        Instantiate(objectPrefab, RandomSpawnPoint(), transform.rotation); // spawn the object prefab at a random x spawn point 
        spawnedObjectCount++; //add 1 to the spawned object count
    }

    private Vector2 RandomSpawnPoint() //set the range for the random x spawnpoint
    {
        Vector2 spawnPoint; 
        spawnPoint.y = minPos.position.y;
        spawnPoint.x = Random.Range(minPos.position.x, maxPos.position.x);
        return spawnPoint; 
    }
}
