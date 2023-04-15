using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ERythmBase { NONE, FIRST, SECOND, THIRD }

public class RythmSystem : MonoBehaviour
{ 
    [HideInInspector] private AudioSource audioSBase;
    [HideInInspector] private AudioSource audioSNoBase;
    [HideInInspector]  private float[] audioSamples = new float[512]; // Array para almacenar los datos de audio

    [Header("Settings")]
    [SerializeField] private float threshold = 0.1f; // Umbral para detectar el ritmo
    [SerializeField] private float multiplierNeeded = 10000f; // Multiplier que utilizo para mejorar el valor de intensidad que obtengo del volumen del audio, para tener más control a la hora de hacer que se mueva
    public ERythmBase rythmState = ERythmBase.NONE;

    [Header("AudioClips Container")]
    [SerializeField] private AudioClip[] audioBase;
    [SerializeField] private AudioClip[] audioNoBase;

    private float intensity;
    
    private void Awake()
    {
        GameObject loopMusic = GameObject.FindGameObjectWithTag("BaseSoundtrack");
        GameObject loopMusicNoBase = GameObject.FindGameObjectWithTag("NoBaseSoundtrack");
        
        if (loopMusic != null)
        {
            audioSBase = loopMusic.GetComponent<AudioSource>();
            audioSNoBase = loopMusicNoBase.GetComponent<AudioSource>();
            audioSBase.Play();
            audioSNoBase.Play();

            SetNewState(ERythmBase.SECOND);
        }
    }
    
    private void Update()
    {
        if (multiplierNeeded < 1)
            multiplierNeeded = 1;

        if (Input.GetKeyDown(KeyCode.P))
        {
            SetNewState(ERythmBase.FIRST);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SetNewState(ERythmBase.SECOND);
        }
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    SetNewState(ERythmBase.SECOND);
        //}

        // Obtener los datos de audio del audio source
        audioSBase.GetSpectrumData(audioSamples, 0, FFTWindow.BlackmanHarris);

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

    private void HandleRythmState()
    {
        audioSBase.Stop();
        audioSNoBase.Stop();

        switch (rythmState)
        {
            case ERythmBase.NONE:
                break;
            case ERythmBase.FIRST:
                audioSBase.clip = audioBase[0];
                audioSNoBase.clip = audioNoBase[0];
                threshold = 60;
                multiplierNeeded = 100000;
                break;
            case ERythmBase.SECOND:
                audioSBase.clip = audioBase[1];
                audioSNoBase.clip = audioNoBase[1];
                threshold = 100;
                multiplierNeeded = 100000;
                break;
            case ERythmBase.THIRD:
                audioSBase.clip = audioBase[2];
                audioSNoBase.clip = audioBase[2];
                break;
        }

        audioSBase.Play();
        audioSNoBase.Play();
    }

    private void SetNewState(ERythmBase newState)
    {
        rythmState = newState;
        HandleRythmState();
    }

    public bool IsRythmMoment()
    {
        return intensity > threshold;
    }
}