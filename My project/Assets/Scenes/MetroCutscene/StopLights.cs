using UnityEngine;

public class StopLights : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject objectToDisable;

    void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            objectToDisable.SetActive(false);
        }
    }
}
