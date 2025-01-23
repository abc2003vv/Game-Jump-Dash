using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Sprite Renderer hiển thị ảnh nền
    public Color[] colors; // Mảng các màu sắc
     public float transitionSpeed = 0.1f; // Tốc độ chuyển đổi màu sắc
    public float changeInterval = 1f; // Thời gian đổi màu

    private int currentIndex = 0; // Chỉ số màu hiện tại
    private float timer = 0f; // Bộ đếm thời gian
    private bool transitioning = false; // Cờ kiểm tra xem có đang chuyển đổi màu không

    void Start()
    {
        // Kiểm tra SpriteRenderer đã được gán chưa
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is not assigned!");
            enabled = false; // Vô hiệu hóa script nếu chưa gán SpriteRenderer
            return;
        }
        // Đặt màu ban đầu
        spriteRenderer.color = colors[currentIndex];
    }

    void Update()
    {
        // Tăng bộ đếm thời gian
        timer += Time.deltaTime;

        // Nếu đến thời điểm đổi màu
        if (timer >= changeInterval)
        {
            timer = 0f;
             StartCoroutine(CrossfadeToNextColor()); // Bắt đầu chuyển đổi màu
        }
    }
    private System.Collections.IEnumerator CrossfadeToNextColor()
    {
        transitioning = true; // Đang chuyển đổi

        // Lấy màu tiếp theo
        int nextColorIndex = (currentIndex + 1) % colors.Length;
        Color nextColor = colors[nextColorIndex];
        nextColor.a = 1f; // Đảm bảo alpha của màu tiếp theo là 1

        // Chuyển dần từ màu hiện tại sang màu mới
        Color currentColor = spriteRenderer.color;
        for (float t = 0f; t <= 1f; t += transitionSpeed * Time.deltaTime)
        {
            spriteRenderer.color = Color.Lerp(currentColor, nextColor, t);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f); // Đảm bảo alpha luôn là 1
            yield return null;
        }

        // Hoàn tất chuyển đổi màu
        spriteRenderer.color = nextColor;
        currentIndex = nextColorIndex;
        transitioning = false; // Kết thúc chuyển đổi
    }
}
