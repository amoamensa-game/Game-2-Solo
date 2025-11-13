using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyPrefab;
    public float spawnRate = 1f;
    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 6f;
    
    [Header("Enemy Scale Variation")]
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    
    private float nextSpawnTime;
    
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver())
        {
            return;
        }
        
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }
    
    void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
            
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            
            float randomScale = Random.Range(minScale, maxScale);
            enemy.transform.localScale = Vector3.one * randomScale;
        }
    }
}
