using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    [SerializeField] protected Instrument[] instruments;
    [SerializeField] protected Instrument baseInstrument;

    [HideInInspector] protected float maxVolume = 0.5f;
    [HideInInspector] protected float minVolume = 0f;
    [HideInInspector] public int currentIteration = 0;
    
    public virtual void InitializeSequence()
    {
        baseInstrument = instruments[1];
        
        foreach (Instrument i in instruments)
        {
            i.beating.InitBeating();
        }
    }

    public virtual void UpdateSoundtracks()
    {
        CheckIfMusicFinalized();

        foreach (Instrument i in instruments)
        {
            i.UpdateSpectrumIntensity();
        }

        foreach (Instrument i in instruments)
        {
            i.beating.UpdateBeating();
        }
    }

    public virtual void StartConfiguration()
    {

    }

    public virtual void NextConfiguration()
    {
        currentIteration++;
    }

    private void ReloadSong()
    {
        foreach (Instrument i in instruments)
        {
            if (i.instrumentRef != null)
            {
                i.instrumentRef.Play();
                i.beating.StartBeating();
            }
        }
    }

    public void CheckIfMusicFinalized()
    {
        foreach (Instrument i in instruments)
        {
            if (i.instrumentRef != null)
            {
                if (i.instrumentRef.isPlaying)
                {
                    return;
                }
                else
                {
                    ReloadSong();
                }
            }
        }
    }

    public float GetThreshold() { return baseInstrument.threshold; }
    public float GetMultiplierNeeded() { return baseInstrument.multiplierNeeded; }
    public void SetBaseInstrument(Instrument newInstrument) { baseInstrument = newInstrument; }
    public void SetBaseInstrument(int i) { baseInstrument = instruments[i]; }
    public Instrument GetBaseInstrument() { return baseInstrument; }
    public Instrument[] GetAllInstruments() { return instruments; }
}