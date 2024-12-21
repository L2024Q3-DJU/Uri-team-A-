using UnityEngine;

public class VolcanoSoundPlayer : MonoBehaviour
{
    [Header("Explosion Sounds")]
    public AudioClip[] explosionSounds;
    public AudioSource audioSource;

    [Header("Random Settings")]
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is not assigned. Adding one automatically.");
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.volume = 1f;
            audioSource.spatialBlend = 0f;
            audioSource.playOnAwake = false;
        }

        Debug.Log($"AudioSource initialized: {audioSource.name}, Volume: {audioSource.volume}, SpatialBlend: {audioSource.spatialBlend}");

        if (explosionSounds == null || explosionSounds.Length == 0)
        {
            Debug.LogError("No explosion sounds assigned!");
        }
    }

    public void PlayRandomExplosionSound()
    {
        Debug.Log("PlayRandomExplosionSound() method called.");

        if (explosionSounds == null || explosionSounds.Length == 0)
        {
            Debug.LogError("No AudioClips in explosionSounds array!");
            return;
        }

        int randomIndex = Random.Range(0, explosionSounds.Length);
        AudioClip selectedClip = explosionSounds[randomIndex];

        if (selectedClip == null)
        {
            Debug.LogError($"AudioClip at index {randomIndex} is null!");
            return;
        }

        Debug.Log($"Selected Clip: {selectedClip.name}, AudioSource: {audioSource.name}");

        if (audioSource == null)
        {
            Debug.LogError("AudioSource is null! Cannot play sound.");
            return;
        }

        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(selectedClip);
        Debug.Log($"Playing sound: {selectedClip.name} on {audioSource.name}");
    }
}