using UnityEngine;
using UnityEngine.UI;

public class DaniSongSimonController : RythmSimonController
{
    private void Start()
    {
        StartSimon();
    }

    public override void HandleSimon()
    {
        base.HandleSimon();
        
        switch (simonMode)
        {
            case ESimonMode.EXAMPLE_SIMON:
                
                switch (RythmSystem.instance.soundtrackManager.currentIteration)
                {
                    case 1:

                        Debug.Log("xd");

                        buttonSequenceController.currentControlToShow.SetActive(true);
                        buttonSequenceController.ShowOnRythmExample();
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

                
                break;
        }
    }
}