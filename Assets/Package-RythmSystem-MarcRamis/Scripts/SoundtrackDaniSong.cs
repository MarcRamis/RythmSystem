public class SoundtrackDaniSong : SoundtrackManager
{
    private void Awake()
    {
    }
    
    public override void RythmOn()
    {
    }

    public override void RythmOff()
    {
    }

    public override void StartConfiguration()
    {
        SetInstrumentOff(audioSources[2]);
        SetInstrumentOff(audioSources[3]);
        SetInstrumentOff(audioSources[4]);

        NextConfiguration();
    }
    
    public override void NextConfiguration()
    {
        base.NextConfiguration();
        
        switch (currentIteration)
        {
            case 1:
                
                SetAudioVolume(audioSources[0], maxVolume);
                SetAudioVolume(audioSources[1], 0.2f);
                
                break;

            case 2:
                break;

            case 3:
                break;

            default:
                break;
        }
    }
}