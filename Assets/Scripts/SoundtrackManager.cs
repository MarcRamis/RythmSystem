using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    [SerializeField] protected List<AudioSource> audioSources;
    [SerializeField] protected AudioClip[] audios;
    [SerializeField] protected float threshold;
    [SerializeField] protected float multiplierNeeded;

    public virtual void ConfigureSoundtrack()
    {
    }
    
    public virtual void RythmOn()
    {
        bool firstOne = true;

        foreach(AudioSource audioSource in audioSources)
        {
            if (!firstOne)
            {
                audioSource.volume = 1;
            }
            else
            {
                firstOne = false;
            }
        }
    }
    
    public virtual void RythmOff()
    {
        bool firstOne = true;

        foreach (AudioSource audioSource in audioSources)
        {
            if (!firstOne)
            {
                audioSource.volume = 0;
            }
            else
            {
                firstOne = false;
            }
        }
    }
    
    public AudioClip[] GetAudios() { return audios; }
    public AudioClip GetAudioBase() { return audios[0]; }
    public float GetThreshold() { return threshold; }
    public float GetMultiplierNeeded() { return multiplierNeeded; }
    public void AddAudioSource(AudioSource audioSource) { audioSources.Add(audioSource); }
    public void CleaAudioSources() { audioSources.Clear(); }
}
