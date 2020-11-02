using UnityEngine;

enum RotationDirection
{
    PLUS,
    MINUS
}

public class PickaxBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _rotationAmount = 0f;
    private const float _maxRotation = 0.3f;
    private const float _minRotation = -0.3f;
    private float _curRotation;
    private RotationDirection _rotationDirection;
    // Start is called before the first frame update
    void Awake()
    {
        _curRotation = 0f;
        _rotationDirection = RotationDirection.PLUS;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_rotationDirection)
        {
            case RotationDirection.PLUS:
                _curRotation += _rotationAmount * Time.deltaTime;
                if (_curRotation > _maxRotation)
                    _rotationDirection = RotationDirection.MINUS;
                break;
            case RotationDirection.MINUS:
                _curRotation -= _rotationAmount * Time.deltaTime;
                if (_curRotation < _minRotation)
                    _rotationDirection = RotationDirection.PLUS;
                break;
        }
        gameObject.transform.Rotate(0, 0, _curRotation);
        //gameObject.transform.Rotate(gameObject.transform.forward, _curRotation, Space.Self);
    }
}