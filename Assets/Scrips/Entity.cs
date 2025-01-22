using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    UIManager uIManager; //  UIManager

    void Start()
    {
        uIManager = FindObjectOfType<UIManager>(); // Tìm đối tượng UIManager
    }

    // kết thúc game nếu va chạm
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            uIManager.gameOver(); 
        }
    }
}