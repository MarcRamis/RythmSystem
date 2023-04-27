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
    [SerializeField] public List<GameObject> currentExampleSequence;
    [SerializeField] public List<GameObject> currentSequence;
    [SerializeField] public GameObject currentControlToShow;
    
    [Space]
    [Header("Buttons Image")]
    [SerializeField] private GameObject square;
    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject triangle;
    [SerializeField] private GameObject circle;
    
    [SerializeField] private GameObject up;
    [SerializeField] private GameObject down;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;
    

    public void CreateSequence(EControlType[] controlType)
    {
        ClearSequence();

        foreach (EControlType control in controlType)
        {
            HandleControlType(control);
        }
        currentControlToShow = currentExampleSequence[0];
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

        currentExampleSequence.Clear();
        currentSequence.Clear();
    }
    
    private void AddControl(GameObject button)
    {
        GameObject newButtonSequence = Instantiate(button, sequenceContainer.transform);
        newButtonSequence.SetActive(false);
        currentExampleSequence.Add(newButtonSequence);

        GameObject newButtonExampleSequence = Instantiate(button, exampleSequenceContainer.transform);
        newButtonExampleSequence.SetActive(false);
        currentSequence.Add(newButtonExampleSequence);
    }
    
    public void ShowOnRythmExample()
    {
        currentControlToShow.SetActive(true);
        NextControlExample();
    }
    
    private void NextControlExample()
    {
        for(int i = 0; i < currentExampleSequence.ToArray().Length - 1; i++)
        {
            if (currentExampleSequence[i] == currentControlToShow)
            {
                if (currentExampleSequence[i + 1] != null)
                {
                    currentControlToShow = currentExampleSequence[i + 1];
                }
                break;
            }
        }
    }

    private void NextControl()
    {
        for (int i = 0; i < currentSequence.ToArray().Length - 1; i++)
        {
            if (currentSequence[i] == currentControlToShow)
            {
                if (currentSequence[i + 1] != null)
                {
                    currentControlToShow = currentSequence[i + 1];
                }
                break;
            }
        }
    }
}