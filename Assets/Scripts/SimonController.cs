using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonController : MonoBehaviour
{
    public RythmSimonController rythmSimonController;
    public EControlType butonPressed;

    private void Start()
    {
        rythmSimonController.StartSimon();
    }
    
    private EControlType GetButtons()
    {
        if (Input.GetButtonDown("Cross"))
        {
            Debug.Log("cross");
            return EControlType.CROSS;
        }

        if (Input.GetButtonDown("Circle"))
        {
            Debug.Log("circle");
            return EControlType.CIRCLE;
        }

        if (Input.GetButtonDown("Square"))
        {
            Debug.Log("square");
            return EControlType.SQUARE;
        }

        if (Input.GetButtonDown("Triangle"))
        {
            Debug.Log("triangle");
            return EControlType.TRIANGLE;
        }

        return EControlType.NONE;
    }
}
