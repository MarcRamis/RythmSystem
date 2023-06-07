using UnityEngine;

// Esta enumeración representa los controles disponibles en el controlador de PS4 (aunque podría ser lo mismo para Xbox)
public enum EControlType { NONE, SQUARE, CROSS, TRIANGLE, CIRCLE, UP, DOWN, RIGHT, LEFT }

// Esta clase representa una secuencia de botones, con un array de EControlType que representa los botones
// que deben ser pulsados en la secuencia correcta.
[System.Serializable]
public class ButtonsSequence
{
    public EControlType[] buttonSequence; // Secuencia de botones
    public bool isCompleted; // Indica si la secuencia se ha completado
    [HideInInspector] public int sequenceCounter; // Contador para llevar el seguimiento del botón actual en la secuencia

    // Este campo se usa para mantener un seguimiento del botón actual en la secuencia
    [SerializeField] public EControlType currentLoopControl; // Botón actual en la secuencia

    // Este método se llama para avanzar al siguiente botón en la secuencia
    public void NextLoopControl()
    {
        currentLoopControl = buttonSequence[sequenceCounter]; // Asignar el siguiente botón en la secuencia al botón actual
    }

    public void SumLoopControl()
    {
        if (sequenceCounter + 1 < buttonSequence.Length) // Verificar si aún hay botones en la secuencia
        {
            sequenceCounter++; // Incrementar el contador para pasar al siguiente botón
            NextLoopControl(); // Asignar el siguiente botón en la secuencia al botón actual
        }
        else
        {
            isCompleted = true; // La secuencia se ha completado
        }
    }

    // Este método se llama para establecer el botón inicial en la secuencia
    public void SetInitControl()
    {
        currentLoopControl = buttonSequence[0]; // Establecer el primer botón de la secuencia como botón actual
        sequenceCounter = 0; // Reiniciar el contador de la secuencia
    }
}