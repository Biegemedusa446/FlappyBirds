using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _resetPosition = -5f;
    [SerializeField] private float _startPosition = 10f;

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if (transform.position.x < _resetPosition)
        {
            transform.position = new Vector3(_startPosition, transform.position.y, transform.position.z);
        }
    }
}
