using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterControllerBase
{
    private Camera camera;//���� ����Ʈ ������ ���� ���

    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main;
    }

    public void OnMove(InputValue input)
    {
        Vector2 moveInput = input.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue input)
    {
        Vector2 aim = input.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(aim);
        aim = (worldPos - (Vector2)transform.position).normalized;

        if (aim.magnitude > 0.9f)
        {
            CallLookEvent(aim);
        }
    }

}
