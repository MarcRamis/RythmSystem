using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ERythmBase { NONE, FIRST, SECOND, THIRD }

public class RythmSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SoundtrackManager soundtrackManager;
    [SerializeField] private GameObject soundtrackPrefab;
    [SerializeField] private GameObject soundtrackParent;

    [HideInInspector] private AudioSource audioBase;
    [HideInInspector] private float[] audioSamples = new float[512]; // Array para almacenar los datos de audio
    
    private float threshold = 0.1f; // Umbral para detectar el ritmo
    private float multiplierNeeded = 10000f; // Multiplier que utilizo para mejorar el valor de intensidad que obtengo del volumen del audio, para tener más control a la hora de hacer que se mueva
    private ERythmBase rythmState = ERythmBase.NONE;
    private float intensity;
    
    private void Awake()
    {
        InitSoundtrack(soundtrackManager);
    }
    
    private void Update()
    {
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
        audioBase.GetSpectrumData(audioSamples, 0, FFTWindow.BlackmanHarris);

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
        switch (rythmState)
        {
            case ERythmBase.NONE:
                Debug.Log("NO MUSIC ASSIGNED ON AWAKE");
                break;

            case ERythmBase.FIRST:

                InitSoundtrack(GetComponent<SoundtrackHiFiRush>());

                break;

            case ERythmBase.SECOND:

                InitSoundtrack(GetComponent<SoundtrackItsFunky>());

                break;

            case ERythmBase.THIRD:

                InitSoundtrack(GetComponent<SoundtrackZapslat>());

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

    private void InitSoundtrack(SoundtrackManager soundtrackManager)
    {
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

    private void InstantiateMusic(AudioClip clip1, AudioClip clip2, float _threshold, float _multiplierNeeded)
    {     
        //audioSBase.clip = clip1;
        //audioSNoBase.clip = clip2;
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
