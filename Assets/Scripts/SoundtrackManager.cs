using System;
using System.Collections.Generic;
using UnityEngine;

// this controls corresponds to the ps4 controller but xbox could be the same
public enum EControlType { SQUARE, CROSS, TRIANGLE, CIRCLE, UP, DOWN, RIGHT, LEFT}

public class SoundtrackManager : MonoBehaviour
{
    [System.Serializable]
    public struct ButtonsSequence
    {
        public EControlType[] buttonSequence;
        public bool isCompleted;
        public AudioSource instrument;
        
        public float multiplierNeeded;
        public float threshold;
    }
    
    [SerializeField] protected List<AudioSource> audioSources;
    [SerializeField] protected AudioClip[] audios;
    
    [SerializeField] protected ButtonsSequence[] buttonSequences;
    [SerializeField] protected ButtonsSequence currentSequence;
    [SerializeField] protected float threshold;
    [SerializeField] protected float multiplierNeeded;
    
    protected float maxVolume = 0.5f;
    protected float minVolume = 0f;
    [HideInInspector] public float intensity;

    public virtual void InitializeSequence()
    {
        currentSequence = CorrectInspectorError();
    }

    private ButtonsSequence CorrectInspectorError()
    {
        // Esto lo hago por el bug del inspector, que el primer elemento no se visualiza correctamente
        if (buttonSequences[0].buttonSequence == null)
        {
           return buttonSequences[1];
        }
        else
        {
            return buttonSequences[0];
        }
    }

    public virtual void RythmOn()
    {
        bool firstOne = true;
        
        foreach(AudioSource audioSource in audioSources)
        {
            if (!firstOne)
            {
                audioSource.volume = maxVolume;
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
                audioSource.volume = minVolume;
            }
            else
            {
                firstOne = false;
            }
        }
    }
    
    public void SetInstrumentOn(AudioSource audioSource)
    {
        audioSource.volume = maxVolume;
    }
    public void SetInstrumentOff(AudioSource audioSource)
    {
        audioSource.volume = minVolume;
    }
    
    public List<AudioSource> GetAudioSources() { return audioSources; }
    public AudioClip[] GetAudios() { return audios; }
    public AudioClip GetAudioBase() { return audios[0]; }
    public float GetThreshold() { return threshold; }
    public float GetMultiplierNeeded() { return multiplierNeeded; }
    public void AddAudioSource(AudioSource audioSource) { audioSources.Add(audioSource); }
    public void ClearAudioSources() { audioSources.Clear(); }
    public ButtonsSequence GetCurrentSequence() { return currentSequence; }
    public bool RythmMoment() { return intensity > currentSequence.threshold; }
}
