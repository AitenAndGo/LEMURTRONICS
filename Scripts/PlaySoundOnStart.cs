using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    public AudioClip soundClip;  // Przypisz dŸwiêk w Inspektorze
    private AudioSource audioSource;

    void Start()
    {
        // Dodaj AudioSource do obiektu, jeœli go nie ma
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;  // Przypisz dŸwiêk do AudioSource
        audioSource.Play();  // Odtwórz dŸwiêk
    }
}
