using UnityEngine;

[System.Serializable]
public class Instrument
{
    public AudioSource instrumentRef;

    public float threshold;
    public float multiplierNeeded;
    public float intensity;
    
    public bool IsRythmMoment() { return (intensity * instrumentRef.volume) > (threshold * instrumentRef.volume);  }
}
