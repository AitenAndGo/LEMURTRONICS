using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    public AudioClip soundClip;  // Przypisz d�wi�k w Inspektorze
    private AudioSource audioSource;

    void Start()
    {
        // Dodaj AudioSource do obiektu, je�li go nie ma
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;  // Przypisz d�wi�k do AudioSource
        audioSource.Play();  // Odtw�rz d�wi�k
    }
}
