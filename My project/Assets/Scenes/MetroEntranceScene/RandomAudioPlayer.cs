using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    // array of audio sources to be played randomly
    public AudioSource[] audioSources;
    //time range between switching audio sources
    public Vector2 timeRange = new Vector2(5,10);

    private float timer;
    private int currentAudioIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentAudioIndex = -1;
        timer = Random.Range(timeRange.x, timeRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        //decrement timer
        timer -= Time.deltaTime;

        // check if the timer has reached zero
        if (timer <= 0)
        {
            //stop the current audio
            if (currentAudioIndex != -1)
                audioSources[currentAudioIndex].Stop();

            // choose a new random audio
            int newAudioIndex = Random.Range(0, audioSources.Length);

            // make sure the new audio is different from the current one
            while (newAudioIndex == currentAudioIndex)
                newAudioIndex = Random.Range(0, audioSources.Length);

            // set the new audio as current
            currentAudioIndex = newAudioIndex;

            // play the new audio
            audioSources[currentAudioIndex].Play();

            //Stop all other audio sources
            for(int i = 0; i < audioSources.Length; i++)
            {
                if(i != currentAudioIndex)
                {
                    audioSources[i].Stop();
                }
            }
            // set a new random timer
            timer = Random.Range(timeRange.x, timeRange.y);
        }
    }
}
