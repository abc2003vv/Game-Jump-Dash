using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 25f;      // Tốc độ di chuyển
    [SerializeField] private Transform Targetlerf;  // Giới hạn bên trái
    [SerializeField] private Transform TargetrIght; // Giới hạn bên phải
    //
    private Vector2 targetPosition; // Vị trí mục tiêu
    private bool isMoving = false;  // Kiểm tra trạng thái di chuyển
    private Rigidbody2D rb;         // RigidBody2D của quả bóng
    private void Awake()
    {
        // Gán AudioManager nếu có
    }
    private void Start()
    {
        // Kiểm tra các đối tượng giới hạn đã gán chưa
        if (!Targetlerf || !TargetrIght)
        {
            print("Giới hạn chưa được gán trong Inspector!");
            enabled = false;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
        MoveBall();
    }

    private void HandleInput()
    {
        // Nhấn chuột để di chuyển quả bóng
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0;

            // Chọn mục tiêu dựa trên vị trí chạm
            targetPosition = touchPosition.x > transform.position.x
                ? TargetrIght.position
                : Targetlerf.position;

            isMoving = true;

            // Phát âm thanh nếu AudioManager được gán
        }
    }

    private void MoveBall()
    {
        // Kiểm tra trạng thái di chuyển
        if (!isMoving) return;

        // Di chuyển quả bóng
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Dừng khi đến gần mục tiêu
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }
}
