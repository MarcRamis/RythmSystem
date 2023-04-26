using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSequenceController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject exampleSequenceContainer;
    [SerializeField] private GameObject sequenceContainer;
    
    [Space]
    [Header("Buttons Image")]
    [SerializeField] private Image square;
    [SerializeField] private Image cross;
    [SerializeField] private Image triangle;
    [SerializeField] private Image circle;
    
    [SerializeField] private Image up;
    [SerializeField] private Image down;
    [SerializeField] private Image right;
    [SerializeField] private Image left;
    
    private void Start()
    {
        EControlType[] newSequence = RythmSystem.instance.soundtrackManager.GetCurrentSequence().buttonSequence;
        CreateSequence(newSequence);
    }

    private void CreateSequence(EControlType[] controlType)
    {
        foreach (EControlType control in controlType)
        {
            HandleControlType(control);
        }
    }

    private void HandleControlType(EControlType control)
    {
        switch (control)
        {
            case EControlType.SQUARE:

                AddControl(square.gameObject);

                break;
            case EControlType.CROSS:

                AddControl(cross.gameObject);

                break;
            case EControlType.TRIANGLE:

                AddControl(triangle.gameObject);

                break;
            case EControlType.CIRCLE:

                AddControl(circle.gameObject);

                break;
            case EControlType.UP:
                break;
            case EControlType.DOWN:
                break;
            case EControlType.RIGHT:
                break;
            case EControlType.LEFT:
                break;
        }
    }

    private void ClearSequence()
    {
        foreach (Transform child in exampleSequenceContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in sequenceContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    
    private void AddControl(GameObject button)
    {
        GameObject newButtonSequence = Instantiate(button, sequenceContainer.transform);
        newButtonSequence.SetActive(false);
        
        GameObject newButtonExampleSequence = Instantiate(button, exampleSequenceContainer.transform);
        newButtonExampleSequence.SetActive(false);
    }
}