using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : AnimationBase
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.OnMoveEvent += WalkAnimation;
    }

    private void WalkAnimation(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > 0.5f);
    }
}
