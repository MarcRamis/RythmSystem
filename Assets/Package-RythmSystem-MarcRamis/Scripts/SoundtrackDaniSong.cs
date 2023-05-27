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

                break;

            case 1:

                duplicatedInstruments[3].SetAudioVolume(0.6f);
                duplicatedInstruments[4].SetAudioVolume(0.6f);

                break;

            case 2:

                duplicatedInstruments[3].SetAudioVolume(0.6f);
                duplicatedInstruments[4].SetAudioVolume(0.6f);

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

                break;

            case 1:

                duplicatedInstruments[3].SetAudioVolume(0f);
                duplicatedInstruments[4].SetAudioVolume(0f);

                break;

            case 2:

                duplicatedInstruments[3].SetAudioVolume(0f);
                duplicatedInstruments[4].SetAudioVolume(0f);

                break;

            default:
                break;
        }
    }
    
    public override void Configurate()
    {
        NoVolume();

        switch (currentIteration)
        {
            case 0:

                duplicatedInstruments[1].SetAudioVolume(1f);
                duplicatedInstruments[2].SetAudioVolume(0.6f);
                duplicatedInstruments[3].SetAudioVolume(0.6f);

                break;

            case 1:

                duplicatedInstruments[5].SetAudioVolume(1f);
                duplicatedInstruments[3].SetAudioVolume(0.6f);
                duplicatedInstruments[4].SetAudioVolume(0.6f);

                baseInstrument = instruments[5];

                break;


            case 2:

                duplicatedInstruments[2].SetAudioVolume(1f);
                duplicatedInstruments[3].SetAudioVolume(0.6f);
                duplicatedInstruments[4].SetAudioVolume(0.6f);

                baseInstrument = instruments[2];

                break;

            default:
                break;
        }
    }

    private void NoVolume()
    {
        duplicatedInstruments[1].SetAudioVolume(0f);
        duplicatedInstruments[2].SetAudioVolume(0f);
        duplicatedInstruments[3].SetAudioVolume(0f);
        duplicatedInstruments[4].SetAudioVolume(0f);
        duplicatedInstruments[5].SetAudioVolume(0f);
    }
    private void MaxVolume()
    {
        duplicatedInstruments[1].SetAudioVolume(1f);
        duplicatedInstruments[2].SetAudioVolume(1f);
        duplicatedInstruments[3].SetAudioVolume(1f);
        duplicatedInstruments[4].SetAudioVolume(1f);
        duplicatedInstruments[5].SetAudioVolume(1f);
    }

    public override void ConfigurateFinal()
    {
        MaxVolume();
    }
}
