using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private readonly int _idle = Animator.StringToHash("IdleBool");

    private WaitForSeconds _waitForSeconds;
    private float _delay;
    private Transform _target;
    private Transform[] _points;
    private int _currentPoint = 0;
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

        _delay = 3f;
        _waitForSeconds = new WaitForSeconds(_delay);
        _target = _points[_currentPoint];

        _coroutine = StartCoroutine(PatrolRoutine());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _target.position, _speed * Time.deltaTime);
    }

    private IEnumerator PatrolRoutine()
    {
        while (true)
        {
            if (transform.position == _target.position)
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

                _target = _points[_currentPoint];
            }

            yield return null;
        }
    }
}
