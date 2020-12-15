using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PushDirection
{
    Left,
    Right
}


public class PushObstacleBehaviour : MonoBehaviour
{
    private float start_x = -3.5f;
    private float end_x = 3.5f;
    [SerializeField] private float speed;
    private PushDirection _pushDirection;
    public BoxCollider _boxCollider;
    
    private Transform _curPosition;
    void Start()
    {
        _boxCollider = GetComponentInChildren<BoxCollider>();
        _curPosition = GetComponent<Transform>();
        _pushDirection = PushDirection.Right;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        switch (_pushDirection)
        {
            case PushDirection.Right:
                _boxCollider.enabled = true;
                if (_curPosition.transform.position.x > end_x)
                {
                    speed *= -1;
                    _pushDirection = PushDirection.Left;
                }
                break;
            case PushDirection.Left:
                _boxCollider.enabled = false;
                if (_curPosition.transform.position.x < start_x)
                {
                    speed *= -1;
                    _pushDirection = PushDirection.Right;
                }
                break;
        }
        gameObject.transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }
}
