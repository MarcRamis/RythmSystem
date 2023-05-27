public class SoundtrackDaniSong : SoundtrackManager
{
    public override void InitializeSoundtracks()
    {
        base.InitializeSoundtracks();
    }

    /// First sequence
    // rytming with clap 
    // play hithat and bajo 

    /// Second sequence
    // rytming with piano 
    // play solo kick and hi-hat
    
    /// Third Sequence
    // rytming with bajo
    // play hi-hat and kick

    public override void RythmOn()
    {
        base.RythmOn();
       
        switch (currentIteration)
        {
            case 0:
                
                duplicatedInstruments[2].SetAudioVolume(0.6f);
                duplicatedInstruments[3].SetAudioVolume(0.6f);

                instruments[2].isBeating = true;
                instruments[3].isBeating = true;

                break;

            case 1:

                duplicatedInstruments[3].SetAudioVolume(0.6f);
                duplicatedInstruments[4].SetAudioVolume(0.6f);

                instruments[3].isBeating = true;
                instruments[4].isBeating = true;

                break;

            case 2:

                duplicatedInstruments[3].SetAudioVolume(0.6f);
                duplicatedInstruments[4].SetAudioVolume(0.6f);

                instruments[3].isBeating = true;
                instruments[4].isBeating = true;

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

                duplicatedInstruments[2].SetAudioVolume(0f);
                duplicatedInstruments[3].SetAudioVolume(0f);

                instruments[2].isBeating = false;
                instruments[3].isBeating = false;

                break;

            case 1:

                duplicatedInstruments[3].SetAudioVolume(0f);
                duplicatedInstruments[4].SetAudioVolume(0f);

                instruments[3].isBeating = false;
                instruments[4].isBeating = false;

                break;

            case 2:

                duplicatedInstruments[3].SetAudioVolume(0f);
                duplicatedInstruments[4].SetAudioVolume(0f);

                instruments[3].isBeating = false;
                instruments[4].isBeating = false;

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

                duplicatedInstruments[1].SetAudioVolume(1f);
                duplicatedInstruments[2].SetAudioVolume(0.6f);
                duplicatedInstruments[3].SetAudioVolume(0.6f);

                instruments[1].isBeating = true;

                break;

            case 1:

                duplicatedInstruments[5].SetAudioVolume(1f);
                duplicatedInstruments[3].SetAudioVolume(0.6f);
                duplicatedInstruments[4].SetAudioVolume(0.6f);

                instruments[5].isBeating = true;

                break;


            case 2:

                duplicatedInstruments[2].SetAudioVolume(1f);
                duplicatedInstruments[3].SetAudioVolume(0.6f);
                duplicatedInstruments[4].SetAudioVolume(0.6f);

                instruments[2].isBeating = true;

                break;

            default:
                break;
        }
    }

    public override void ConfigurateFinal()
    {
        MaxVolume();
    }
}
