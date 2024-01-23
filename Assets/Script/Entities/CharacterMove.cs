using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private CharacterControllerBase controller;
    [SerializeField] private float speed;

    [SerializeField] SpriteRenderer sprite;

    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        controller = GetComponent<CharacterControllerBase>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnLookEvent += MousePos;
    }

    private void MousePos(Vector2 direction)
    {
        FlipCharacter(direction);
    }

    private void FlipCharacter(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//각도 얻기

        sprite.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void Move(Vector2 direction)
    {
        moveDirection = direction;
    }

    private void MakeMove(Vector2 direction)
    {
        direction = direction * speed;//방향에 속도를 곱함

        rigidbody.velocity = direction;
        //transform.position += new Vector3(direction.x, direction.y, 0);
    }

    private void FixedUpdate()
    {
        MakeMove(moveDirection);
    }
}
