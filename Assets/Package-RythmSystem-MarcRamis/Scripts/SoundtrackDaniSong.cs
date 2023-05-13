public class SoundtrackDaniSong : SoundtrackManager
{
    public override void InitializeSequence()
    {
        base.InitializeSequence();

        //instruments[1].SetAudioVolume(0);
        //instruments[2].SetAudioVolume(1);
        //instruments[3].SetAudioVolume(1);
        //instruments[4].SetAudioVolume(1);
        //instruments[5].SetAudioVolume(1);
    }

    public override void StartConfiguration()
    {
        NextConfiguration();
    }
    
    public override void NextConfiguration()
    {
        base.NextConfiguration();
        
        switch (currentIteration)
        {
            case 1:
                
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