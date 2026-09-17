using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 1.8f;
    [SerializeField] private float minY = -2f;
    [SerializeField] private float maxY = 2f;

    private float timer;

    private void Update()
    {
        if (GameManager.Instance.State != GameManager.GameState.Playing)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    private void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);

        Instantiate(pipePrefab, spawnPosition, Quaternion.identity, transform);
    }
}