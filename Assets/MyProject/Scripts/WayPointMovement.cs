using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private readonly int _idle = Animator.StringToHash("isIdle");

    private WaitForSeconds _waitForSeconds;
    private Transform[] _points;
    private int _currentPoint;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Coroutine _coroutine;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _currentPoint = 0;
        _waitForSeconds = new WaitForSeconds(_delay);

        _coroutine = StartCoroutine(PatrolRoutine());
    }

    private IEnumerator PatrolRoutine()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                     _points[_currentPoint].position, _speed * Time.deltaTime);

            if (transform.position == _points[_currentPoint].position)
            {
                _animator.SetBool(_idle, true);

                yield return _waitForSeconds;

                _animator.SetBool(_idle, false);
                _spriteRenderer.flipX = true;
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                    _spriteRenderer.flipX = false;
                }
            }

            yield return null;
        }
    }
}
