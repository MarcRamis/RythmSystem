using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private RythmSystem rythmSystem;
    [SerializeField] private GameObject boxDamage;
    private bool isRythmMoment;
    private bool canRythm = false;
    
    [Header("Feedback")]
    [SerializeField] private TrailRenderer trailRenderer_RythmTime;
    [SerializeField] private TrailRenderer trailRender_FinalCombo;
    
    private float attackCd = 0.5f;
    private float rythmCd = 0.5f;
    private bool attackIsReady = true;
    private int comboCount;
    private int maxCombo = 3;

    private void Awake()
    {
        trailRenderer_RythmTime.emitting = false;
        trailRender_FinalCombo.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        isRythmMoment = rythmSystem.IsRythmMoment();
        if(isRythmMoment)
        {
            canRythm = true;
            Invoke(nameof(ResetRythm), rythmCd);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (attackIsReady)
            {
                attackIsReady = false;
                Invoke(nameof(ResetAttack), attackCd);
                
                if (canRythm)
                {
                    Debug.Log("Rythm Time!");
                    trailRenderer_RythmTime.emitting = true;
                    Invoke(nameof(ResetEffect1), 1f);
                    comboCount++;
                }

                if (comboCount >= maxCombo)
                {
                    animator.SetTrigger("FinalCombo");
                    trailRender_FinalCombo.emitting = true;
                    Invoke(nameof(ResetEffect2), 2f);
                    comboCount = 0;
                }
                else
                {
                    animator.SetTrigger("Punch");
                }
            }
        }
    }

    private void ResetAttack()
    {
        attackIsReady = true;
    }
    private void ResetRythm()
    {
        canRythm = false;
    }
    private void ResetEffect1()
    {
        trailRenderer_RythmTime.emitting = false;
    }
    private void ResetEffect2()
    {
        trailRender_FinalCombo.emitting = false;
    }
}
