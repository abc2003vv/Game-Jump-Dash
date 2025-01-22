using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntitySpawner2 : MonoBehaviour
{
    public GameObject[] EntityPrefabs; // Danh sách các prefab chướng ngại vật
    public float XLeft = -2f;            // TargetLerf trên trục X
    public float XRight = 2f;            // TargetRight trên trục X
    public float spawnYPosition = 6f;   // Vị trí Y spawn (phía trên màn hình)
    public float fallSpeed = -5f;       // Tốc độ rơi của chướng ngại vật

    private void Start()
    {
        // Bắt đầu spawn với khoảng thời gian spawnInterval
        InvokeRepeating(nameof(Spawn), 0f, 0.5f);
    }
    private void Spawn()
    {
        // Chọn vị trí spawn ngẫu nhiên trong phạm vi từ XLeft đến XRight
        float randomX = Random.Range(XLeft, XRight);
        Vector2 spawnPosition = new Vector2(randomX, spawnYPosition);

        // Random chọn một prefab từ danh sách obstaclePrefabs
        GameObject random = EntityPrefabs[Random.Range(0, EntityPrefabs.Length)];

        // Tạo đối tượng tại vị trí đã chọn
        GameObject obstacle = Instantiate(random, spawnPosition, Quaternion.identity);

        // nếu OBJ có RB thì gán cho đối tượng đó 
        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0f, fallSpeed); // Gán vận tốc rơi xuống
        }
    }
}
