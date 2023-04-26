using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESoundtracks { FIRST, SECOND, THIRD, FOURTH, COUNT}

public enum ERythmMode { BASE, SIMON}

public class RythmSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public SoundtrackManager soundtrackManager;
    [SerializeField] private GameObject soundtrackPrefab;
    [SerializeField] private GameObject soundtrackParent;
    
    [Header("Settings")]
    [SerializeField] private ESoundtracks soundtrackState = ESoundtracks.FIRST;
    [SerializeField] private ERythmMode rythmMode = ERythmMode.BASE;
    
    [HideInInspector] private AudioSource audioBase;
    [HideInInspector] public AudioSource audioExtraBase;
    [HideInInspector] private float[] audioSamples = new float[512]; // Array para almacenar los datos de audio
    
    public static RythmSystem instance;

    private float threshold = 0.1f; // Umbral para detectar el ritmo
    private float multiplierNeeded = 10000f; // Multiplier que utilizo para mejorar el valor de intensidad que obtengo del volumen del audio, para tener más control a la hora de hacer que se mueva
    private float intensity;
    private float extraIntensity;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        SetNewState(soundtrackState);
        //SetNewMode(rythmMode);
    }
    
    private void Update()
    {
        CheckIfMusicFinalized();
        ManageInputs();

        HandleRythmMode(rythmMode);
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
    
    private void CalculateRythm(AudioSource audioSource)
    {
        // Obtener los datos de audio del audio source
        audioSource.GetSpectrumData(audioSamples, 0, FFTWindow.BlackmanHarris);

        // Sumar los valores absolutos de las muestras de audio para obtener una medida de la intensidad del ritmo
        float sum = 0f;
        for (int i = 0; i < audioSamples.Length; i++)
        {
            sum += Mathf.Abs(audioSamples[i]);
        }
        intensity = sum / audioSamples.Length;
        intensity *= multiplierNeeded;

        if (IsRythmMoment())
        {
            //Debug.Log(intensity);
        }
    }
    
    private void CalculateExtraRythm(AudioSource audioSource)
    {
        // Obtener los datos de audio del audio source
        audioSource.GetSpectrumData(audioSamples, 0, FFTWindow.BlackmanHarris);

        // Sumar los valores absolutos de las muestras de audio para obtener una medida de la intensidad del ritmo
        float sum = 0f;
        for (int i = 0; i < audioSamples.Length; i++)
        {
            sum += Mathf.Abs(audioSamples[i]);
        }
        
        soundtrackManager.intensity = sum / audioSamples.Length;
        soundtrackManager.intensity *= soundtrackManager.GetCurrentSequence().multiplierNeeded;
    }

    private void HandleRythmState(ESoundtracks newState)
    {
        switch (newState)
        {
            case ESoundtracks.FIRST:

                InitSoundtrack(GetComponent<SoundtrackHiFiRush>());

                break;

            case ESoundtracks.SECOND:

                InitSoundtrack(GetComponent<SoundtrackItsFunky>());

                break;

            case ESoundtracks.THIRD:

                InitSoundtrack(GetComponent<SoundtrackZapslat>());
                
                break;
                
            case ESoundtracks.FOURTH:

                InitSoundtrack(GetComponent<SoundtrackDaniSong>());

                break;
            case ESoundtracks.COUNT:
                break;
        }
    }
    
    private void ClearChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void InitSoundtrack(SoundtrackManager _soundtrackManager)
    {
        soundtrackManager = _soundtrackManager;

        ClearChildren(soundtrackParent.transform);
        bool firstOne = true;
        
        foreach (AudioClip audioClip in soundtrackManager.GetAudios())
        {
            GameObject gameObject = Instantiate(soundtrackPrefab, soundtrackParent.transform);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();

            soundtrackManager.AddAudioSource(audioSource);

            if (firstOne)
            {
                audioBase = audioSource;
                firstOne = false;
            }
        }
        
        threshold = soundtrackManager.GetThreshold();
        multiplierNeeded = soundtrackManager.GetMultiplierNeeded();
    }

    private void ReloadSong()
    {
        foreach (AudioSource audioSource in soundtrackManager.GetAudioSources())
        {
            audioSource.Play();
        }
    }
    
    private void CheckIfMusicFinalized()
    {
        foreach (AudioSource audioSource in soundtrackManager.GetAudioSources())
        {
            if (audioSource.isPlaying)
            {
                return;
            }
            else
            {
                ReloadSong();
            }
        }
    }
    
    private void SetNewState(ESoundtracks newState)
    {
        soundtrackState = newState;
        HandleRythmState(soundtrackState);
    }
    
    private void SetNewMode(ERythmMode newState)
    {
        rythmMode = newState;
    }
    
    private void HandleRythmMode(ERythmMode rythmMode)
    {
        CalculateRythm(audioBase);

        switch (rythmMode)
        {
            case ERythmMode.BASE:

                break;
            case ERythmMode.SIMON:

                //CalculateExtraRythm(audioExtraBase);

                break;
        }
    }

    public bool IsRythmMoment()
    {
        return intensity > threshold;
    }
    
    public bool IsRythmExtraMoment(float _intensity, float _threshold)
    {
        return _intensity > _threshold;
    }
}