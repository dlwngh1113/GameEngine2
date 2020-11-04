using UnityEngine;

enum RotationDirection
{
    PLUS,
    MINUS
}

public class PickaxBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _rotationAmount = 10f;
    private const float _maxRotation = 60f;
    private const float _minRotation = -60f;
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
                _curRotation = gameObject.transform.rotation.eulerAngles.z;
                if (_curRotation > _maxRotation)
                {
                    _rotationDirection = RotationDirection.MINUS;
                    _rotationAmount = -(_rotationAmount);
                }
                break;
            case RotationDirection.MINUS:
                _curRotation = -(gameObject.transform.rotation.eulerAngles.z) + 180f;
                if (_curRotation < _minRotation)
                {
                    _rotationDirection = RotationDirection.PLUS;
                    _rotationAmount = Mathf.Abs(_rotationAmount);
                }
                break;
        }
        gameObject.transform.Rotate(0f, 0f, _rotationAmount * Time.deltaTime);
    }
}