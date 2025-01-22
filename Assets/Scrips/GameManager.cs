using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // Singleton instance
    private int currentScore = 0;       // Điểm hiện tại
    private int bestScore = 0;          // Điểm cao nhất
    
    public TextMeshProUGUI scoreText;         // hiển thị điểm trong PanelGameover
    public TextMeshProUGUI textCurrentScore; // Hiển thị điểm hiện tại
    public TextMeshProUGUI textBestScore;    // Hiển thị điểm cao nhất

    // Singleton Pattern
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Lấy BestScore từ PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void Start()
    {
        // Hiển thị BestScore và CurrentScore khi bắt đầu
        UpdateScore();
    }

    public void AddScore(int amount)
    {
        // Chỉ cộng điểm hiện tại
        currentScore += amount;

        // Cập nhật điểm hiện tại trên giao diện
        UpdateScore();
    }

    public void ResetScore()
    {
        // Reset điểm về 0
        currentScore = 0;
        UpdateScore();
    }

    public void showScoreGameOver()
    {
         scoreText.text = "Score: "+ currentScore.ToString();
    }
    public void EndGame()
    {
        // Kiểm tra và lưu BestScore
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore); // Lưu điểm cao nhất vào bộ nhớ
        }

        // Hiển thị lại BestScore
        UpdateScore();

        // Reset điểm hiện tại cho lần chơi mới
        ResetScore();
    }

    private void UpdateScore()
    {
        // Cập nhật giao diện với điểm hiện tại và điểm cao nhất
        if (textCurrentScore != null)
        {
            textCurrentScore.text = "" + currentScore;
        }

        if (textBestScore != null)
        {
            textBestScore.text = "BEST: " + bestScore;
        }

        showScoreGameOver();
    }
    
}