using System.Collections;
using UnityEngine;

public class LightFlickerArray : MonoBehaviour
{
    public Light[] lights;
    public float flickerDuration = 0.05f;
    public int minFlickerCount = 2;
    public int maxFlickerCount = 5;
    public float cooldown = 10.0f;
    private Light lastLightFlicker;

    private void Start()
    {
        StartCoroutine(FlickerLights());
    }

    private IEnumerator FlickerLights()
    {
        while (true)
        {
            // Choose a random light to flicker
            Light lightToFlicker = lights[Random.Range(0, lights.Length)];
            //if the last light flicker is the same as the current light flicker then wait for cooldown
            if (lightToFlicker == lastLightFlicker)
            {
                yield return new WaitForSeconds(cooldown);
            }

            // Flicker the light multiple times
            int flickerCount = Random.Range(minFlickerCount, maxFlickerCount);
            for (int i = 0; i < flickerCount; i++)
            {
                lightToFlicker.enabled = !lightToFlicker.enabled;
                yield return new WaitForSeconds(flickerDuration);
            }

            lightToFlicker.enabled = true;

            lastLightFlicker = lightToFlicker;
        }
    }
}
