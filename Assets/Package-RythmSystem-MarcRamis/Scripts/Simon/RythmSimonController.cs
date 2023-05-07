using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmSimonController : MonoBehaviour
{
    [SerializeField] protected ButtonSequenceController buttonSequenceController;
    
    [SerializeField] protected Image imgTest;
    [SerializeField] protected Image imgTest2;
    [SerializeField] protected Image imgTest3;
    [SerializeField] protected Image imgTest4;
    
    protected bool rythmTest1;
    protected bool rythmTest2;
    protected bool rythmTest3;
    protected bool rythmTest4;
    
    protected ButtonsSequence buttonsSequence;
    protected bool rythmMoment;
    protected bool simonIsPlaying = false;
    
    [Header("Settings")]
    [SerializeField] protected float rythmCd = 0.5f;
    [SerializeField] protected float rythmButtonsCd = 0.5f;
    protected bool canRythm = false;
    protected bool canRythmButtons = false;
    protected bool rythmOnce = true;
    protected bool rythmOnceButtons = true;

    private void Awake()
    {
        RythmSystem.instance.beat.OnBeat += Rythm;
    }

    private void Update()
    {   
        if (simonIsPlaying)
        {
            if (InputController.instance.CheckIfCorrectButton(buttonsSequence.currentLoopControl) && rythmOnceButtons)
            {
                if (canRythmButtons)
                {
                    rythmOnceButtons = false;
                    HandleSimon(ESimonMode.SIMONSAYS);
                }
            }

            if (canRythm)
            {
                if (rythmOnce)
                {
                    rythmOnce = false;
                    HandleSimon(ESimonMode.EXAMPLE_SIMON);
                }
            }
        }
    }

    private void Rythm()
    {
        canRythm = true;
        canRythmButtons = true;
        Invoke(nameof(ResetRythm), rythmCd);
        Invoke(nameof(ResetRythmButtons), rythmButtonsCd);
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
    
    private void ResetRythmButtons()
    {
        canRythmButtons = false;
        rythmOnceButtons = true;
    }

    public virtual void HandleSimon(ESimonMode simonMode)
    {
        switch (simonMode)
        {
            case ESimonMode.EXAMPLE_SIMON:

                buttonSequenceController.ShowOnRythm(buttonSequenceController.GetExampleSequence());
                
                if (buttonSequenceController.CheckIfLoopFinished(buttonSequenceController.GetExampleSequence()))
                {
                    buttonSequenceController.FinishedMode(RythmSystem.instance.simonMode);
                }

                break;

            case ESimonMode.SIMONSAYS:
                
                buttonSequenceController.ShowOnRythm(buttonSequenceController.GetPlayerSequence());

                if (buttonSequenceController.CheckIfLoopFinished(buttonSequenceController.GetPlayerSequence()))
                {
                    buttonSequenceController.FinishedMode(RythmSystem.instance.simonMode);
                }

                break;
        }
    }

    private void Test()
    {
        rythmTest1 = RythmSystem.instance.soundtrackManager.GetAllInstruments()[2].IsIntensityGreater();
        rythmTest2 = RythmSystem.instance.soundtrackManager.GetAllInstruments()[3].IsIntensityGreater();
        rythmTest3 = RythmSystem.instance.soundtrackManager.GetAllInstruments()[4].IsIntensityGreater();
        rythmTest4 = RythmSystem.instance.soundtrackManager.GetAllInstruments()[5].IsIntensityGreater();

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
    
    public void StartSimon()
    {
        buttonsSequence = RythmSystem.instance.soundtrackManager.GetBaseSequence();

        EControlType[] newSequence = RythmSystem.instance.soundtrackManager.GetBaseSequence().buttonSequence;
        buttonSequenceController.CreateSequence(newSequence);
        RythmSystem.instance.soundtrackManager.StartConfiguration();

        PlaySimon();
    }
    protected void NextSequence()
    {
    }


    protected void PlaySimon()
    {
        simonIsPlaying = true;
    }
    protected void StopSimon()
    {
        simonIsPlaying = false;
    }
}
