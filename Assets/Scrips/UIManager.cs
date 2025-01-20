using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject PanelGameover;
    public GameObject PanelStar;
    // Start is called before the first frame update
    public void startGame()
    {
        PanelStar.SetActive(false);
        Time.timeScale = 1;
    }
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
