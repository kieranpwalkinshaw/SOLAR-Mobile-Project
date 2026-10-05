using UnityEngine;

public class DartObjectSpawning : MonoBehaviour
{
    public static DartObjectSpawning instance;

    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;

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
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            spawnObject();
        }
    }

    private void spawnObject()
    {
        Instantiate(objectPrefab, RandomSpawnPoint(), transform.rotation);
        spawnedObjectCount++;
    }

    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint;
        spawnPoint.y = minPos.position.y;
        spawnPoint.x = Random.Range(minPos.position.x, maxPos.position.x);
        return spawnPoint;
    }
}
