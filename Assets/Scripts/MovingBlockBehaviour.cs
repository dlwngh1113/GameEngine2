using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
    TOLEFT,
    TORIGHT
};
public class MovingBlockBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _offset = 1f;
    private float _maxOffset;
    private float _minOffset;
    private Direction _direction;
    // Start is called before the first frame update
    void Awake()
    {
        _direction = Direction.TOLEFT;
        _minOffset = transform.localPosition.x - _offset;
        _maxOffset = transform.localPosition.x + _offset; 
    }

    // Update is called once per frame
    void Update()
    {
        switch (_direction)
        {
            case Direction.TOLEFT:
                if(transform.localPosition.x > _minOffset)
                {
                    transform.localPosition = transform.localPosition + new Vector3(-_speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    _direction = Direction.TORIGHT;
                }
                break;
            case Direction.TORIGHT:
                if (transform.localPosition.x < _maxOffset)
                {
                    transform.localPosition = transform.localPosition + new Vector3(_speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    _direction = Direction.TOLEFT;
                }
                break;
        }
    }
}
