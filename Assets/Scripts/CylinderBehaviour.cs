using UnityEngine;

public class CylinderBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _rotationAmount = 10f;
    void Update()
    {
        gameObject.transform.Rotate(0f, _rotationAmount * Time.deltaTime, 0f);
    }
}