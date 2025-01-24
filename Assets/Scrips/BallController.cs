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
    
    GameManager gameManager;

    AudioManager audioManager;

    

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();  // gọi Audio
    }
    private void Start()
    {
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
            audioManager.PlaySFXSound(audioManager.tab);
            // Chọn mục tiêu dựa trên vị trí chạm
            Vector2 newTargetPosition = touchPosition.x > transform.position.x
                ? TargetrIght.position
                : Targetlerf.position;

            // Chỉ cộng điểm nếu bóng thay đổi trạng thái và bắt đầu di chuyển
            if (!isMoving || targetPosition != newTargetPosition)
            {
                isMoving = true;
                targetPosition = newTargetPosition;

                // Cộng điểm khi bóng bắt đầu di chuyển
                GameManager.Instance.AddScore(1);
            }
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
