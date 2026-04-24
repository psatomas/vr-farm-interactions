using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ChickenSound : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip cluckClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource missing!");
        }
    }

    public void PlayCluck()
    {
        if (audioSource == null || cluckClip == null) return;

        Debug.Log("Playing cluck");

        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(cluckClip);
    }
}