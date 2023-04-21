using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ERythmBase { NONE, FIRST, SECOND, THIRD }

public class RythmSystem : MonoBehaviour
{
    [HideInInspector] private AudioSource audioSBase;
    [HideInInspector] private AudioSource audioSNoBase;
    [HideInInspector] private float[] audioSamples = new float[512]; // Array para almacenar los datos de audio

    [Header("Settings")]
    [SerializeField] private float threshold = 0.1f; // Umbral para detectar el ritmo
    [SerializeField] private float multiplierNeeded = 10000f; // Multiplier que utilizo para mejorar el valor de intensidad que obtengo del volumen del audio, para tener más control a la hora de hacer que se mueva
    public ERythmBase rythmState = ERythmBase.NONE;
    [SerializeField] private GameObject loopMusic;
    [SerializeField] private GameObject loopMusicNoBase;

    [Header("AudioClips Container")]
    [SerializeField] private AudioClip[] audioBase;
    [SerializeField] private AudioClip[] audioNoBase;

    private float intensity;
    
    private void Awake()
    {
        audioSBase = loopMusic.GetComponent<AudioSource>();
        audioSNoBase = loopMusicNoBase.GetComponent<AudioSource>();

        SetNewState(rythmState);
    }
    
    private void Update()
    {
        if (multiplierNeeded < 1)
            multiplierNeeded = 1;

        ManageInputs();

        CalculateRythm();
    }

    private void ManageInputs()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetNewState(ERythmBase.FIRST);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SetNewState(ERythmBase.SECOND);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetNewState(ERythmBase.THIRD);
        }
    }

    private void CalculateRythm()
    {
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
            Debug.Log(intensity);
        }
    }

    private void HandleRythmState()
    {
        audioSBase.Stop();
        audioSNoBase.Stop();

        switch (rythmState)
        {
            case ERythmBase.NONE:
                Debug.Log("NO MUSIC ASSIGNED ON AWAKE");
                break;

            case ERythmBase.FIRST:

                InstantiateMusic(audioBase[0], audioNoBase[0], 60, 100000);

                break;

            case ERythmBase.SECOND:

                InstantiateMusic(audioBase[1], audioNoBase[1], 100, 100000);

                break;

            case ERythmBase.THIRD:

                InstantiateMusic(audioBase[2], null, 90, 100000);

                break;
        }
        
        audioSBase.Play();
        audioSNoBase.Play();
    }

    private void InstantiateMusic(AudioClip clip1, AudioClip clip2, float _threshold, float _multiplierNeeded)
    {
        audioSBase.clip = clip1;
        audioSNoBase.clip = clip2;
        threshold = _threshold;
        multiplierNeeded = _multiplierNeeded;
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