using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public bool Idle;
    public bool Walk;
    public bool Interact;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Idle)
        {
            IdleAnimation();
        }
        if (Walk)
        {
            WalkAnimation();
        }
        if (Interact)
        {
            InteractAnimation();
        }
    }

    // Update is called once per frame
    public void IdleAnimation()
    {
        animator.SetTrigger("GoIdle");
        animator.ResetTrigger("GoInteract");
        animator.ResetTrigger("GoWalk");
        animator.ResetTrigger("GoIdleLook");
        StartCoroutine(waitIdleLook());
    }
    public void WalkAnimation()
    {
        StopAllCoroutines();
        animator.SetTrigger("GoWalk");
        animator.ResetTrigger("GoInteract");
        animator.ResetTrigger("GoIdle");
        animator.ResetTrigger("GoIdleLook");
    }
    public void InteractAnimation()
    {
        StopAllCoroutines();
        animator.SetTrigger("GoInteract");
        animator.ResetTrigger("GoWalk");
        animator.ResetTrigger("GoIdle");
        animator.ResetTrigger("GoIdleLook");
    }

    private IEnumerator waitIdleLook()
    {
        yield return new WaitForSeconds(5);
        animator.SetTrigger("GoIdleLook");
        yield return new WaitForSeconds(2);
        animator.SetTrigger("GoIdle");
    }
    
}
