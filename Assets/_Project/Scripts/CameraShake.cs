using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration = 0.3f;
    [SerializeField] private float magnitude = 0.25f;

    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.localPosition;
    }

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float strength = magnitude * (1f - elapsed / duration);
            Vector2 offset = Random.insideUnitCircle * strength;

            transform.localPosition = startPosition + new Vector3(offset.x, offset.y, 0f);

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localPosition = startPosition;
    }
}