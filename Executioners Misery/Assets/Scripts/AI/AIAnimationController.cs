using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimationController : MonoBehaviour
{
    public Animator animator;
    public bool Idle;
    public bool Walk;
    public bool Talk;
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
        if (Talk)
        {
            TalkAnimation();
        }
    }

    // Update is called once per frame
    public void IdleAnimation()
    {
        animator.SetTrigger("GoIdle");
        animator.ResetTrigger("GoTalk");
        animator.ResetTrigger("GoWalk");
    }
    public void WalkAnimation()
    {
        StopAllCoroutines();
        animator.SetTrigger("GoWalk");
        animator.ResetTrigger("GoTalk");
        animator.ResetTrigger("GoIdle");
    }
    public void TalkAnimation()
    {
        StopAllCoroutines();
        animator.SetTrigger("GoTalk");
        animator.ResetTrigger("GoWalk");
        animator.ResetTrigger("GoIdle");
    }
}
