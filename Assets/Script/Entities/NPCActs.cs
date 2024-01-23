using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class NPCActs : MonoBehaviour
{
    GameManager gameManager;

    private Transform Target { get; set; }
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField][Range(0f, 10f)] private float noticeRange;

    // Start is called before the first frame update
    public void Start()
    {
        gameManager = GameManager.instance;
        Target = gameManager.Player;
    }

    //�Ÿ�
    private float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, Target.position);
    }

    //����
    private Vector2 DirectionToTarget()
    {
        return (Target.position - transform.position).normalized;
    }

    private void FlipCharacter(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//���� ���

        sprite.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;
        //������ �������� ����
        if (DistanceToTarget() < noticeRange)
        {
            direction = DirectionToTarget();
        }

        FlipCharacter(direction);
    }

    
}
