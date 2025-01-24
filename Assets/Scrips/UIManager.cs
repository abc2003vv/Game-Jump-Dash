using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject PanelGameover;
    public GameObject PanelStar;
    AudioManager audioManager;

    // start game
    public void startGame()
    {
        PanelStar.SetActive(false);
        Time.timeScale = 1;
         audioManager = GameObject.FindObjectOfType<AudioManager>();
        audioManager.PlayBackgroundMusic();
    }
    void Start()
    {
        Time.timeScale = 0;
    }
    // game over
    public void gameOver()
    {
        PanelGameover.SetActive(true);
        Time.timeScale = 0;
        audioManager.StopBackgroundMusic();
      
    }
    //Restart game
    public void RestartGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.EndGame();
        }
        SceneManager.LoadScene("Scene"); 
    }
   
}
