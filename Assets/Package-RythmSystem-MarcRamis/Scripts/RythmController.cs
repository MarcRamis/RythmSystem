using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESoundtracks { FIRST, SECOND, COUNT}
public enum ERythmMode { SCHEDULED, FREE }

public class RythmController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public SoundtrackManager soundtrackManager;
    [SerializeField] public List<SoundtrackManager> soundtracks;
    
    [Header("Settings")]
    [SerializeField] private ESoundtracks soundtrackState = ESoundtracks.FIRST;

    public ERythmMode rythmMode;
    public static RythmController instance;
    
    public Beat beat;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
        beat = new Beat();
        HandleRythmMode(rythmMode);
    }

    private void Start()
    {
        soundtrackManager.InitializeSoundtracks();
    }

    private void Update()
    {
        soundtrackManager.UpdateSoundtracks();

        ManageInputs();

        beat.Update(soundtrackManager.GetAllInstruments());

    }

    private void ManageInputs()
    {
        // Cambiar la canción
        if (Input.GetKeyDown(KeyCode.P))
        {
            soundtrackState += 1;
            if (soundtrackState == ESoundtracks.COUNT)
            {
                soundtrackState = ESoundtracks.FIRST;
            }
            SetNewState(soundtrackState);
        }
        
        // Cambiar el modo
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (rythmMode == ERythmMode.SCHEDULED)
            {
                rythmMode = ERythmMode.FREE;
            }
            else
            {
                rythmMode = ERythmMode.SCHEDULED;
            }
            SetNewMode(rythmMode);
        }
    }
    

    private void HandleSoundtrack(ESoundtracks newState)
    {
        soundtrackManager.StopSoundtracks();
        switch (newState)
        {
            case ESoundtracks.FIRST:

                soundtrackManager = soundtracks[0];

                break;

            case ESoundtracks.SECOND:

                soundtrackManager = soundtracks[1];

                break;

            case ESoundtracks.COUNT:
                break;
        }

        soundtrackManager.InitializeSoundtracks();
    }


    private void HandleRythmMode(ERythmMode newMode)
    {
        SetNewState(soundtrackState);

        switch(newMode)
        {
            case ERythmMode.SCHEDULED:

                soundtrackManager.ConfigurateScheduled();

                break;

            case ERythmMode.FREE:
                
                soundtrackManager.Configurate();

                break;
        }
    }
    
    private void SetNewMode(ERythmMode newMode)
    {
        rythmMode = newMode;
        HandleRythmMode(rythmMode);
    }

    private void SetNewState(ESoundtracks newState)
    {
        soundtrackState = newState;
        HandleSoundtrack(soundtrackState);
    }
    
}
