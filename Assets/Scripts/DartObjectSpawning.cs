using UnityEngine;

public class DartObjectSpawning : MonoBehaviour
{
    public static DartObjectSpawning instance;
    //declare private variables for the object prefab, min and max spawn positions
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;
    //declare variables for spawn timer, interval, min interval and a count of spawned objects
    public float spawnTimer;
    public float spawnInterval = 2f;
    public float minSpawnInterval = 1f;
    public int spawnedObjectCount;

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
        spawnTimer += Time.deltaTime; //increase the spawn timer using deltatime
        if (spawnTimer >= spawnInterval) //if the spawn timer is >=the spawn interval
        {
            spawnTimer = 0; //reset the spawn timer
            spawnObject(); //call the spawn object function
        }
    }

    private void spawnObject()
    {
        Instantiate(objectPrefab, RandomSpawnPoint(), transform.rotation); //spawn the object prefab at a random spawn point
        spawnedObjectCount++; //increase the spawned object count by 1
    }

    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint; //declare a variable for the spawn point
        spawnPoint.y = minPos.position.y; //set the y pos of the spawn point to the min pos variable
        spawnPoint.x = Random.Range(minPos.position.x, maxPos.position.x); //set the x pos of the spawn point to a random value between the min and max positions
        return spawnPoint;
    }
}
