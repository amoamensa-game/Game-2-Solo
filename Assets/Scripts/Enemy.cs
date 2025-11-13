using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]
    public float fallSpeed = 2f;
    
    [Header("Rotation Settings")]
    public float rotationSpeed = 50f;
    
    private float randomRotationDirection;
    
    void Start()
    {
        randomRotationDirection = Random.Range(-1f, 1f);
    }
    
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        
        transform.Rotate(0f, 0f, rotationSpeed * randomRotationDirection * Time.deltaTime);
        
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
