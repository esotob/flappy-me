using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip scoreClip;
    [SerializeField] private AudioClip hitClip;

    [Range(0f, 1f)]
    [SerializeField] private float volume = 0.6f;

    private AudioSource source;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        Play(jumpClip);
    }

    public void PlayScore()
    {
        Play(scoreClip);
    }

    public void PlayHit()
    {
        Play(hitClip);
    }

    private void Play(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        source.PlayOneShot(clip, volume);
    }
}