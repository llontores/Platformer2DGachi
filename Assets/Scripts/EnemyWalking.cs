using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyWalking : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _leftEdge;
    [SerializeField] private Transform _rightEdge;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _counter;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_counter];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _counter++;

            if (_counter >= _points.Length)
            {
                _counter = 0;
            }
        }

        _spriteRenderer.flipX = (transform.position.x == _leftEdge.position.x) ? true :
        (transform.position.x == _rightEdge.position.x) ? false : _spriteRenderer.flipX;
    }
}
