using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESoundtracks { FIRST, SECOND, THIRD, FOURTH, COUNT}

public enum ERythmMode { BASE, SIMON}
public enum ESimonMode { EXAMPLE_SIMON, SIMONSAYS }

public class RythmSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public SoundtrackManager soundtrackManager;
    
    [Header("Settings")]
    [SerializeField] private ESoundtracks soundtrackState = ESoundtracks.FIRST;
    [SerializeField] private ERythmMode rythmMode = ERythmMode.BASE;
    
    [HideInInspector] private AudioSource audioBase;
    [HideInInspector] public AudioSource audioExtraBase;
    [HideInInspector] private float[] audioSamples = new float[512]; // Array para almacenar los datos de audio
    
    public ESimonMode simonMode = ESimonMode.EXAMPLE_SIMON;

    public static RythmSystem instance;
    public Beat beat;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        //SetNewState(soundtrackState);
        //SetNewMode(rythmMode);

        beat = new Beat();
    }

    private void Start()
    {
        soundtrackManager.InitializeSequence();
    }

    private void Update()
    {
        soundtrackManager.UpdateSoundtracks();

        //CheckIfMusicFinalized();
        //ManageInputs(); // para testear rápido diferentes canciones

        beat.Update(soundtrackManager.GetBaseInstrument().IsIntensityGreater());
    }

    private void ManageInputs()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            soundtrackState += 1;
            if (soundtrackState == ESoundtracks.COUNT)
            {
                soundtrackState = ESoundtracks.FIRST;
            }
            SetNewState(soundtrackState);
        }
    }


    private void HandleRythmState(ESoundtracks newState)
    {
        switch (newState)
        {
            case ESoundtracks.FIRST:


                break;

            case ESoundtracks.SECOND:

                break;

            case ESoundtracks.THIRD:

                
                break;
                
            case ESoundtracks.FOURTH:


                break;
            case ESoundtracks.COUNT:
                break;
        }
    }

    
    private void SetNewState(ESoundtracks newState)
    {
        soundtrackState = newState;
        HandleRythmState(soundtrackState);
    }
    
    public void SetNewMode(ERythmMode newState)
    {
        rythmMode = newState;
    }
   
    public void SetNewSimonMonde(ESimonMode eSimonMode)
    {
        simonMode = eSimonMode;
    }
}
