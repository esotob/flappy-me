using UnityEngine;

public class AmbientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minInterval = 2f;
    [SerializeField] private float maxInterval = 6f;
    [SerializeField] private float minY = -3f;
    [SerializeField] private float maxY = 4f;
    [SerializeField] private bool spawnOnStart = true;
    [SerializeField] private int maxAlive = 5;

    private float timer;
    private float nextSpawn;

    private void Start()
    {
        if (spawnOnStart)
        {
            Camera cam = Camera.main;
            float halfWidth = cam.orthographicSize * cam.aspect;
            float randomX = Random.Range(-halfWidth * 0.8f, halfWidth * 0.8f);
            Spawn(randomX);
        }

        nextSpawn = Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer < nextSpawn)
        {
            return;
        }

        timer = 0f;
        nextSpawn = Random.Range(minInterval, maxInterval);

        if (transform.childCount >= maxAlive)
        {
            return;
        }

        Spawn(transform.position.x);
    }

    private void Spawn(float x)
    {
        Vector3 position = new Vector3(x, Random.Range(minY, maxY), 0f);
        Instantiate(prefab, position, Quaternion.identity, transform);
    }
}