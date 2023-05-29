using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SequenceController : MonoBehaviour
{
    // Definici�n de variables p�blicas y privadas
    [Header("References")]
    [SerializeField] protected List<ButtonsSequence> sequences; // Lista de secuencias que se reproducir�n en esta canci�n
    [SerializeField] protected ButtonsSequence currentSequence; // La secuencia actual en la que se est� trabajando

    // M�todo Init para inicializar el juego
    public void Init()
    {
        foreach (ButtonsSequence bs in sequences)
        {
            if (bs != sequences[0])
            {
                bs.isCompleted = false;
                bs.SetInitControl();
            }
        }
    }

    public void UpdateSequence()
    {
        FollowingSequence();
        FollowingRythm();
    }

    public void FollowingSequence()
    {
        // Pasamos al siguiente bot�n de la secuencia
        NextControl();
    }

    private void NextControl()
    {
        currentSequence.SumLoopControl();
    }

    public bool NextSequence()
    {
        // Iteramos sobre la lista de secuencias
        for (int i = 0; i < sequences.Count - 1; i++)
        {
            // Comprobamos si la secuencia actual es la que estamos mostrando
            if (sequences[i] == currentSequence)
            {
                // Si la siguiente secuencia no es nula,
                // actualizamos la secuencia actual y creamos una nueva secuencia
                if (sequences[i + 1] != null)
                {
                    currentSequence = sequences[i + 1];
                    
                    // Sumamos la configuraci�n al soundtrackManager
                    RythmController.instance.soundtrackManager.SelectConfiguration(i);

                    return true;
                }
                // Si la siguiente secuencia es nula, salimos del loop
                break;
            }
        }
        return false;
    }

    public void Finish()
    {
        // Configuramos la fase final del soundtrackManager
        RythmController.instance.soundtrackManager.ConfigurateFinal();
    }
    
    public void FollowingRythm()
    {
        // Activamos el rythmo del soundtrackManager
        RythmController.instance.soundtrackManager.RythmOn();
    }
    
    public void FollowingRandomRythm()
    {
        RythmController.instance.soundtrackManager.RythmOff();
        RythmController.instance.soundtrackManager.RythmOnFreed();
        NotFollowingSequence();
    }

    public bool CheckIfLoopFinished(List<GameObject> sequence)
    {
        // Iteramos sobre la lista de botones en la secuencia
        foreach (GameObject sq in sequence)
        {
            // Si encontramos un bot�n que no est� activo, devolvemos false
            if (sq.activeSelf == false)
                return false;
        }

        // Si todos los botones est�n activos, devolvemos true
        return true;
    }

    public bool CheckIfPlayerFinished()
    {
        // Iteramos sobre la lista de secuencias
        foreach (ButtonsSequence sq in sequences)
        {
            // Si encontramos una secuencia completada, devolvemos true
            if (sq.isCompleted == true)
                return true;
        }

        return false;
    }
    
    // M�todo que se llama cuando el jugador ha presionado un bot�n incorrecto y la sincronizaci�n se pierde
    public void WrongSync()
    {
        RythmController.instance.soundtrackManager.RestSyncInstrument();
        NotFollowingSequence();
        Init();
    }
    
    public void NotFollowingSequence()
    {
        currentSequence = null;
        currentSequence = new ButtonsSequence();
    }

    // M�todo para obtener la secuencia actual
    public ButtonsSequence GetCurrentSequence() { return currentSequence; }
    
    public bool CheckIfFollowingASequence(EControlType eControlType)
    {
        if (currentSequence.currentLoopControl != EControlType.NONE)
            return true;
       
        else
        {
            foreach (ButtonsSequence bs in sequences)
            {
                if (bs != sequences[0])
                {
                    // Quiero comprobar la primera vez que est� siguiendo un ritmo
                    // Si no sigue el ritmo, hay que devolver false
                    if (bs.currentLoopControl == eControlType)
                    {
                        currentSequence = bs;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    // M�todo para obtener el control actual de la secuencia
    public EControlType GetCurrentControl() { return currentSequence.currentLoopControl; }
}