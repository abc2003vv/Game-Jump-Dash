using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner2 : MonoBehaviour
{
    public GameObject obstaclePrefab;    // Prefab chướng ngại vật
    public float spawnInterval = 1f;     // Khoảng thời gian giữa các lần spawn

    // Phạm vi vị trí spawn (Vector2: xMin, xMax)
    public Vector2 spawnRangeX = new Vector2(-2f, 2f);
    public float spawnYPosition = 6f;   // Vị trí Y spawn nằm ngoài màn hình (phía trên)

    void Start()
    {
        // Gọi hàm SpawnObstacle sau mỗi khoảng thời gian spawnInterval
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Lấy vị trí X ngẫu nhiên trong phạm vi spawnRangeX
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);

        // Tạo vị trí spawn
        Vector2 spawnPosition = new Vector2(randomX, spawnYPosition);

        // Tạo chướng ngại vật tại vị trí đã chọn
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Kiểm tra nếu chướng ngại vật có Rigidbody2D để thêm chuyển động
        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0f, -5f);  // Tốc độ rơi
        }
    }
}
