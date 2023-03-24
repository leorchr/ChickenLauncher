using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAnimation : MonoBehaviour
{
    public Animator animator;
    public GameObject chicken;
    public SkinnedMeshRenderer meshRenderer;
    public ChickenProjectile chickenProjectile;
    private bool finishedAction = true;
    private IEnumerator coroutine;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Momentum()
    {
        if (finishedAction)
        {
            finishedAction = false;
            animator.SetBool("Launch",true);
        }
    }
    public void Release()
    {
        if (animator.GetBool("Launch"))
        {
            animator.Play("ChickenRelease", -1, GetCurrentClipTime()*-1+1);
            animator.SetBool("Launch",false);
        }
    }

    public void FinishRelease()
    {
        finishedAction = true;
        meshRenderer.enabled = false;
        chickenProjectile.StartLaunch();
        coroutine = chickenProjectile.delayBeforeShoot(meshRenderer);
        StartCoroutine(coroutine);
    }

    private float GetCurrentClipTime()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        AnimationClip clip = clipInfo[0].clip;
        float positionInAnimation = clip.length * stateInfo.normalizedTime;
        if (positionInAnimation > clip.length) positionInAnimation = clip.length;
        return positionInAnimation;
    }
}
