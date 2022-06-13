using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimationManager : MonoBehaviour
{
    public Animator animator;
    public bool Open;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Open)
        {
            OpenAnimation();
            StartCoroutine(closeGate());
        }
    }

    // Update is called once per frame
    public void OpenAnimation()
    {
        animator.SetTrigger("GoOpen");
        animator.ResetTrigger("GoClose");
    }
    public void CloseAnimation()
    {
        StopAllCoroutines();
        animator.SetTrigger("GoClose");
        animator.ResetTrigger("GoOpen");
    }

    IEnumerator closeGate()
    {
        yield return new WaitForSeconds(3);
        CloseAnimation();
    }
}
