using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Sprite Renderer để hiển thị ảnh nền
    public Color[] colors; // Mảng các màu sắc
    public float transitionSpeed = 0.1f; // Tốc độ chuyển đổi màu sắc
    public float colorChangeInterval = 5f; // Khoảng thời gian giữa các lần thay đổi màu

    private int currentColorIndex = 0; // Chỉ số của màu hiện tại
    private float timer = 0f; // Bộ đếm thời gian
    private bool transitioning = false; // Cờ kiểm tra xem có đang chuyển đổi màu không

    void Start()
    {
        if (spriteRenderer == null)
        {
            print("Chưa gán Sprite Renderer!");
            return;
        }

        if (colors.Length == 0)
        {
            print("Mảng màu đang trống!");
            return;
        }

        // Đặt màu sắc ban đầu
        Color initialColor = colors[currentColorIndex];
        initialColor.a = 1f;
        spriteRenderer.color = initialColor;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= colorChangeInterval && !transitioning)
        {
            timer = 0f;
            StartCoroutine(CrossfadeToNextColor());
        }
    }

    private IEnumerator CrossfadeToNextColor()
    {
        transitioning = true;

        // Chọn màu tiếp theo (ngẫu nhiên hoặc theo thứ tự)
        int nextColorIndex;
        do
        {
            nextColorIndex = Random.Range(0, colors.Length);
        } while (nextColorIndex == currentColorIndex);

        Color nextColor = colors[nextColorIndex];
        nextColor.a = 1f;

        // Chuyển đổi từ màu hiện tại sang màu mới
        Color currentColor = spriteRenderer.color;
        for (float t = 0f; t <= 1f; t += transitionSpeed * Time.deltaTime)
        {
            float smoothT = Mathf.SmoothStep(0, 1, t); // Mượt mà hơn với SmoothStep
            spriteRenderer.color = Color.Lerp(currentColor, nextColor, smoothT);
            yield return null;
        }

        // Hoàn tất chuyển đổi
        spriteRenderer.color = nextColor;
        currentColorIndex = nextColorIndex;
        transitioning = false;
    }
}
