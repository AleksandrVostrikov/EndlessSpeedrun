using UnityEngine;

public class SeedRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    
    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
