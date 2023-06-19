using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Spider : MonoBehaviour
{
    [SerializeField] private AILerp path;
    [SerializeField] private Animator animator;

    [Header("Direction Animation")]
    [SerializeField] private AnimationClip animUp;
    [SerializeField] private AnimationClip animDown;
    [SerializeField] private AnimationClip animLeft;
    [SerializeField] private AnimationClip animRight;
    private AnimatorOverrideController animatorOverrideController;

    private void Start()
    {
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        animatorOverrideController["Up"] = animUp;
        animatorOverrideController["Down"] = animDown;
        animatorOverrideController["Left"] = animLeft;
        animatorOverrideController["Right"] = animRight;
    }


    public void MoveTo(Vector2 pos)
    {
        path.destination = pos;
        path.SearchPath();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("VelocityX", path.velocity.normalized.x);
        animator.SetFloat("VelocityY", path.velocity.normalized.y);
        Debug.Log(path.velocity.normalized);
    }
}
