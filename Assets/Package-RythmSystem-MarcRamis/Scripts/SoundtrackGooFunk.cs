using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackGooFunk : SoundtrackManager
{
    private List<AudioSource> chords;
    
    public override void InitializeSoundtracks()
    {
        base.InitializeSoundtracks();
        
        chords.Add(instruments[3].instrumentRef);
        chords.Add(instruments[4].instrumentRef);
    }

    /// First sequence
    // rytming with bombo 
    // play chords & drumkit

    /// Second sequence
    // rytming with bass 
    // play bombo & chords

    /// Third sequence
    // rytming with drumkit 
    // play melodia & chords && bombo


    public override void RythmOn()
    {
        base.RythmOn();

        switch (currentIteration)
        {
            case 0:

                SetChordsVolume(0.6f);
                duplicatedInstruments[5].SetAudioVolume(0.6f);

                instruments[3].isBeating = true;
                instruments[4].isBeating = true;
                instruments[5].isBeating = true;

                break;

            case 1:

                duplicatedInstruments[2].SetAudioVolume(0.6f);
                SetChordsVolume(0.6f);

                instruments[2].isBeating = true;
                instruments[3].isBeating = true;
                instruments[4].isBeating = true;

                break;

            case 2:

                SetChordsVolume(0.6f);
                duplicatedInstruments[2].SetAudioVolume(0.6f);
                duplicatedInstruments[6].SetAudioVolume(0.6f);

                instruments[2].isBeating = true;
                instruments[3].isBeating = true;
                instruments[4].isBeating = true;
                instruments[6].isBeating = true;

                break;

            default:
                break;
        }
    }

    public override void RythmOff()
    {
        base.RythmOff();
        switch (currentIteration)
        {
            case 0:

                SetChordsVolume(0f);
                duplicatedInstruments[5].SetAudioVolume(0f);

                instruments[3].isBeating = false;
                instruments[4].isBeating = false;
                instruments[5].isBeating = false;

                break;

            case 1:

                duplicatedInstruments[2].SetAudioVolume(0f);
                SetChordsVolume(0f);

                instruments[2].isBeating = false;
                instruments[3].isBeating = false;
                instruments[4].isBeating = false;

                break;

            case 2:
                
                SetChordsVolume(0f);
                duplicatedInstruments[2].SetAudioVolume(0f);
                duplicatedInstruments[6].SetAudioVolume(0f);

                instruments[2].isBeating = false;
                instruments[3].isBeating = false;
                instruments[4].isBeating = false;
                instruments[6].isBeating = false;

                break;

            default:
                break;
        }
    }

    public override void Configurate()
    {
        NoVolume();
        NoBeating();

        switch (currentIteration)
        {
            case 0:
                
                instruments[2].isBeating = true;
                duplicatedInstruments[2].SetAudioVolume(1f);

                SetChordsVolume(0.6f);
                duplicatedInstruments[5].SetAudioVolume(0.6f);              

                break;

            case 1:

                instruments[1].isBeating = true;
                duplicatedInstruments[1].SetAudioVolume(1f);
                
                duplicatedInstruments[2].SetAudioVolume(0.6f);
                SetChordsVolume(0.6f);

                break;


            case 2:

                instruments[5].isBeating = true;
                duplicatedInstruments[5].SetAudioVolume(1f);
                
                SetChordsVolume(0.6f);
                duplicatedInstruments[2].SetAudioVolume(0.6f);
                duplicatedInstruments[6].SetAudioVolume(0.6f);

                break;

            default:
                break;
        }
    }

    private void SetChordsVolume(float vol)
    {
        foreach(AudioSource audioSource in chords)
        {
            audioSource.volume = vol;
        }
    }

    public override void ConfigurateFinal()
    {
        MaxVolume();
    }
}