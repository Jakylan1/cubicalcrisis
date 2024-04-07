using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Singleton instance
    private static SoundManager instance;

    // Audio source to play sounds
    private AudioSource audioSource;

    // Initialize singleton instance
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this one
        }
    }

    // Play a sound clip
    public static void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        if (instance != null && clip != null)
        {
            instance.audioSource.PlayOneShot(clip, volume);
        }
    }
}
