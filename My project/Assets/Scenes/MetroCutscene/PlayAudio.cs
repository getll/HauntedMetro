using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip clip;
    public float volume = 1f;
    public float delay = 5f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlaySound", delay); // play the sound after the specified delay
    }

    void PlaySound()
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
