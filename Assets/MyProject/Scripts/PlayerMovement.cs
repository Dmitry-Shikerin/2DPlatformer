using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private readonly int _run = Animator.StringToHash("isRun");
    private readonly int _jump = Animator.StringToHash("isJump");

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Surfece>(out Surfece surface))
        {
            _animator.SetBool(_jump, false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Surfece>(out Surfece surface))
        {
            _animator.SetBool(_jump, true);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            _spriteRenderer.flipX = false;

            _animator.SetBool(_run, true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool(_run, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

            _spriteRenderer.flipX = true;

            _animator.SetBool(_run, true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool(_run, false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, _speed * Time.deltaTime, 0);

        }
    }
}
