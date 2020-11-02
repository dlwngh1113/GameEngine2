using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _rotationAmount = 0.1f;
    private float _curRotation;
    void Awake()
    {
        _curRotation = 0f;
    }

    void Update()
    {
        _curRotation += _rotationAmount * Time.deltaTime;
        Vector3 tmpAngle = gameObject.transform.localRotation.eulerAngles;
        tmpAngle.x = _curRotation;
        gameObject.transform.localRotation = Quaternion.Euler(tmpAngle);
    }
}
