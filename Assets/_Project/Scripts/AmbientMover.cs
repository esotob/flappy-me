using UnityEngine;

public class AmbientMover : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waveAmplitude = 0f;
    [SerializeField] private float waveFrequency = 3f;
    [SerializeField] private float offscreenMargin = 2f;

    private float baseY;
    private float offset;
    private float leftLimit;
    private float rightLimit;

    private void Start()
    {
        baseY = transform.position.y;
        offset = Random.Range(0f, 10f);

        Camera cam = Camera.main;
        float halfWidth = cam.orthographicSize * cam.aspect;
        leftLimit = cam.transform.position.x - halfWidth - offscreenMargin;
        rightLimit = cam.transform.position.x + halfWidth + offscreenMargin;
    }

    private void Update()
    {
        float x = transform.position.x - speed * Time.deltaTime;
        float y = baseY;

        if (waveAmplitude > 0f)
        {
            y += Mathf.Sin((Time.time + offset) * waveFrequency) * waveAmplitude;
        }

        transform.position = new Vector3(x, y, transform.position.z);

        bool leftTheScreen = (speed > 0f && x < leftLimit) || (speed < 0f && x > rightLimit);

        if (leftTheScreen)
        {
            Destroy(gameObject);
        }
    }
}