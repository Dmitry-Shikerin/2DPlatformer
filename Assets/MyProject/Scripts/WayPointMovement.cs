using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform _target;
    private Transform[] _points;
    private int _currentPoint = 0;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _target = _points[_currentPoint];

        StartCoroutine(PatrolRoutine());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private IEnumerator PatrolRoutine()
    {
        while (true)
        {
            if (transform.position == _target.position)
            {
                _animator.SetBool("IdleBool", true);

                yield return new WaitForSeconds(3f);

                _animator.SetBool("IdleBool", false);

                _spriteRenderer.flipX = true;

                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;

                    _spriteRenderer.flipX = false;
                }

                _target = _points[_currentPoint];
            }

            yield return null;
        }
    }
}
