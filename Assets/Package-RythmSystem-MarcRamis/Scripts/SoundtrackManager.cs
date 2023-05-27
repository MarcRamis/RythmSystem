﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    [SerializeField] protected Instrument[] instruments; // this are the instruments that will calculate the spectrum
    [SerializeField] protected List<Instrument> duplicatedInstruments; // This are the instruments that will be heared by the player

    [HideInInspector] protected float maxVolume = 0.5f;
    [HideInInspector] protected float minVolume = 0f;
    [HideInInspector] public int currentIteration = 0;
    
    public virtual void InitializeSoundtracks()
    {
        foreach(Instrument i in instruments)
        {
            if (i.instrumentRef != null)
            {
                i.instrumentRef.volume = 0.001f;
            }
        }

        ReloadSong();

        currentIteration = 0;
        //Configurate();
    }

    public virtual void StopSoundtracks()
    {
        foreach (Instrument i in instruments)
        {
            if (i.instrumentRef != null)
            {
                i.instrumentRef.Stop();
            }
        }
        foreach (Instrument i in duplicatedInstruments)
        {
            if (i.instrumentRef != null)
            {
                i.instrumentRef.Stop();
            }
        }
    }

    public virtual void StartSongLater()
    {
        foreach (Instrument i in duplicatedInstruments)
        {
            if (i.instrumentRef != null)
            {
                i.instrumentRef.Play();
            }
        }
    }

    public virtual void UpdateSoundtracks()
    {
        CheckIfMusicFinalized();

        foreach (Instrument i in instruments)
        {
            if (i.instrumentRef != null)
            {
                i.UpdateSpectrumIntensity();
            }
        }
    }

    public virtual void RythmOn()
    {
    }
    public virtual void RythmOff()
    {
    }
    
    public virtual void Scheduled()
    {
        // Next configuration is called every time secuence controller of the simon game changes his current secuence to the next
        foreach(Instrument i in duplicatedInstruments)
        {
            i.SetAudioVolume(1f);
            i.isBeating = true;
        }
    }

    public virtual void Configurate()
    {
        // Next configuration is called every time secuence controller of the simon game changes his current secuence to the next
    }
    
    public virtual void ConfigurateFinal()
    {
        // Called when the secuence in the simon game is finished
    }
    
    protected virtual void ReloadSong()
    {
        foreach (Instrument i in instruments)
        {
            if (i.instrumentRef != null)
            {
                i.instrumentRef.Play();
            }
        }
        Invoke(nameof(StartSongLater), 0.005f);
    }

    public void SumConfiguration()
    {
        // Sum aconfiguration is called every time secuence controller of the simon game changes his current secuence to the next
        currentIteration++;
        Configurate();
    }

    protected virtual void CheckIfMusicFinalized()
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

    protected void NoBeating()
    {
        foreach (Instrument i in instruments)
        {
            if (i.instrumentRef != null)
            {
                i.isBeating = false;
            }
        }
    }

    protected void AllBeating()
    {
        foreach (Instrument i in instruments)
        {
            if (i.instrumentRef != null)
            {
                i.isBeating = true;
            }
        }
    }

    protected void NoVolume()
    {
        foreach (Instrument i in duplicatedInstruments)
        {
            if (i.instrumentRef != null)
            {
                i.SetAudioVolume(0f);
            }
        }
    }
    protected void MaxVolume()
    {
        foreach (Instrument i in duplicatedInstruments)
        {
            if (i.instrumentRef != null)
            {
                i.SetAudioVolume(1f);
            }
        }
    }

    public Instrument[] GetAllInstruments() { return instruments; }
}