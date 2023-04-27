using System;
using UnityEngine;
using UnityEngine.UI;

public enum ESimonMode { EXAMPLE_SIMON, SIMONSAYS }

public class RythmSimonController : MonoBehaviour
{
    [SerializeField] protected ButtonSequenceController buttonSequenceController;

    [SerializeField] protected Image imgTest;
    [SerializeField] protected Image imgTest2;
    [SerializeField] protected Image imgTest3;
    [SerializeField] protected Image imgTest4;
    
    protected ESimonMode simonMode = ESimonMode.EXAMPLE_SIMON;
    
    protected bool rythmTest1;
    protected bool rythmTest2;
    protected bool rythmTest3;
    protected bool rythmTest4;
    
    protected ButtonsSequence buttonsSequence;
    protected bool rythmMoment;
    protected bool simonIsPlaying = false;
    
    [Header("Settings")]
    [SerializeField] protected float rythmCd = 0.5f;
    protected bool canRythm = false;
    protected bool rythmOnce = true;

    private void Update()
    {
        Test();

        if (simonIsPlaying)
        {
            rythmMoment = buttonsSequence.instrument.IsRythmMoment();

            if (rythmMoment)
            {
                canRythm = true;
                Invoke(nameof(ResetRythm), rythmCd);
            }

            if (canRythm)
            {
                if (rythmOnce)
                {
                    rythmOnce = false;
                    HandleSimon();
                }
            }
        }
    }

    private void ResetOnce()
    {
        rythmOnce = true;
    }

    private void ResetRythm()
    {
        canRythm = false;
        rythmOnce = true;
    }

    public virtual void HandleSimon()
    {
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


                break;
        }
    }

    private void Test()
    {
        rythmTest1 = RythmSystem.instance.soundtrackManager.GetAllButtonsSequence()[2].instrument.IsRythmMoment();
        rythmTest2 = RythmSystem.instance.soundtrackManager.GetAllButtonsSequence()[3].instrument.IsRythmMoment();
        rythmTest3 = RythmSystem.instance.soundtrackManager.GetAllButtonsSequence()[4].instrument.IsRythmMoment();
        rythmTest4 = RythmSystem.instance.soundtrackManager.GetAllButtonsSequence()[5].instrument.IsRythmMoment();

        if (rythmTest1)
        {
            imgTest.color = Color.black;
            Invoke(nameof(ResetRythm1), 0.5f);
        }
        if (rythmTest2)
        {
            imgTest2.color = Color.red;
            Invoke(nameof(ResetRythm2), 0.5f);
        }
        if (rythmTest3)
        {
            imgTest3.color = Color.green;
            Invoke(nameof(ResetRythm3), 0.5f);
        }
        if (rythmTest4)
        {
            imgTest4.color = Color.cyan;
            Invoke(nameof(ResetRythm4), 0.5f);
        }
    }
    
    private void ResetRythm1()
    {
        imgTest.color = Color.white;
    }

    private void ResetRythm2()
    {
        imgTest2.color = Color.white;
    }

    private void ResetRythm3()
    {
        imgTest3.color = Color.white;
    }
    
    private void ResetRythm4()
    {
        imgTest4.color = Color.white;
    }

    protected void StartSimon()
    {
        buttonsSequence = RythmSystem.instance.soundtrackManager.GetCurrentSequence();

        simonIsPlaying = true;

        EControlType[] newSequence = RythmSystem.instance.soundtrackManager.GetCurrentSequence().buttonSequence;
        buttonSequenceController.CreateSequence(newSequence);
        RythmSystem.instance.soundtrackManager.StartConfiguration();
    }

    protected void NextSequence()
    {
    }

    protected void ExitSimon()
    {
        simonIsPlaying = false;
    }
}
