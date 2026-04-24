using UnityEngine;

/// <summary>
/// Handles chicken sound interaction in the VR farm environment.
/// Plays a randomized "cluck" sound when triggered, adding variation
/// through pitch and volume modulation to make audio feel more natural.
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class ChickenSound : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Audio")]
    [SerializeField] private AudioClip cluckClip;

    [Header("Variation")]
    [SerializeField] private Vector2 pitchRange = new Vector2(0.9f, 1.1f);
    [SerializeField] private Vector2 volumeRange = new Vector2(0.8f, 1f);

    [Header("Control")]
    [SerializeField] private float cooldown = 0.2f;

    private float lastPlayTime;

    /// <summary>
    /// Initializes required components.
    /// Ensures the GameObject has an AudioSource for playback.
    /// </summary>
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays the chicken cluck sound with randomized pitch and volume.
    /// Includes a cooldown to prevent audio spam from rapid interactions.
    /// </summary>
    public void PlayCluck()
    {
        if (cluckClip == null) return;

        // Prevents repeated triggering in a short time window
        if (Time.time - lastPlayTime < cooldown) return;

        lastPlayTime = Time.time;

        // Adds variation to avoid repetitive sound pattern
        audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
        float volume = Random.Range(volumeRange.x, volumeRange.y);

        audioSource.PlayOneShot(cluckClip, volume);
    }
}