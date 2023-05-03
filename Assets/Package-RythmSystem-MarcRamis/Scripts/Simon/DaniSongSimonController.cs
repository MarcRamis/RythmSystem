using UnityEngine;
using UnityEngine.UI;

public class DaniSongSimonController : RythmSimonController
{
    public override void HandleSimon(ESimonMode simonMode)
    {
        base.HandleSimon(simonMode);
        
        switch (simonMode)
        {
            case ESimonMode.EXAMPLE_SIMON:
                
                switch (RythmSystem.instance.soundtrackManager.currentIteration)
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
                


                break;
                
            case ESimonMode.SIMONSAYS:

                switch (RythmSystem.instance.soundtrackManager.currentIteration)
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

                break;
        }
    }
}