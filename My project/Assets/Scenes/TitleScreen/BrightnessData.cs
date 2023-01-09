using UnityEngine;

[CreateAssetMenu(menuName = "Data/Brightness Data")]
public class BrightnessData : ScriptableObject
{
    public float brightness;

    private void Awake()
    {
        // Make the brightness data object persistent between scenes
        DontDestroyOnLoad(this);
    }
}