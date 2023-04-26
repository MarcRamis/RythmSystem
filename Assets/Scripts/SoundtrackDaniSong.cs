public class SoundtrackDaniSong : SoundtrackManager
{
    private void Awake()
    {

    }
    
    public override void RythmOn()
    {
        SetInstrumentOn(audioSources[2]);
        SetInstrumentOn(audioSources[3]);
        SetInstrumentOn(audioSources[4]);
    }

    public override void RythmOff()
    {
        SetInstrumentOff(audioSources[2]);
        SetInstrumentOff(audioSources[3]);
        SetInstrumentOff(audioSources[4]);
    }
}