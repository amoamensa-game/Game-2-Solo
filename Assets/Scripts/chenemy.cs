
using UnityEngine;


public class chenemy : MonoBehaviour
{
    
    
    [Header("Shooting Settings")]
    public GameObject eggsPrefab;
    public Transform dropPoint;
    public float fireRate = 0.5f;
     private float nextFireTime;
    
    [Header("Boundaries")]
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;
    

    
    void Awake()
    {
       
    }
    
    void Update()
    {
       
        HandleShooting();
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    
    void ReadInput()
    {
        
    }
    
 
    
    void HandleShooting()
    {
      if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    
    void Shoot()
    {
        if (eggsPrefab != null && dropPoint != null)
        {
            Instantiate(eggsPrefab, dropPoint.position, Quaternion.identity);
        }
    }
    
   
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseLife();
            }
            Destroy(collision.gameObject);
        }
    }
}
