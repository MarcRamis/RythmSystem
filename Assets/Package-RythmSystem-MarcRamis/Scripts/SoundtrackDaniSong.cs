public class SoundtrackDaniSong : SoundtrackManager
{
    private void Awake()
    {
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