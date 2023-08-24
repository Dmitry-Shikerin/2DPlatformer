using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private readonly int _run = Animator.StringToHash("RunBool");
    private readonly int _jump = Animator.StringToHash("JumpBool");

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.D)) //Движение вправо
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            _spriteRenderer.flipX = false;

            _animator.SetBool(_run, true);
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool(_run, false);
        }

        if (Input.GetKey(KeyCode.A)) //Движение влево
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

            _spriteRenderer.flipX = true;

            _animator.SetBool(_run, true);
        }

        if (Input.GetKeyUp(KeyCode.A)) 
        {
            _animator.SetBool(_run, false);
        }

        if (Input.GetKey(KeyCode.Space)) //Прыжек
        {
            transform.Translate( 0, _speed * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool(_jump, true);
        }

        if (Input.GetKeyUp (KeyCode.Space))
        {
            _animator.SetBool(_jump, false);
        }
    }
}
