using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
   
    public static playercontrol pc;
    public TextMeshProUGUI bestText; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;   
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalBestText;
    public bool started;
    public bool gameOver;
    public float time = 120;
    public GameObject gameplayui;
    public GameObject gameoverui;
    public GameObject mainMenuui;
    public GameObject pausemenu;
    public static bool GameisPaused = false;
    void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

      

        time -= Time.deltaTime;

        if (time <= 1)
        {
            GameOver();
           
        }

        var minutes = Mathf.FloorToInt(time / 60f);
        var seconds = Mathf.FloorToInt(time - minutes * 60f);
         timerText.text = string.Format("{0:0}i{1:00}", minutes, seconds);
       
    }
    public void GameOver()
    {
        gameOver = true;
        gameplayui.SetActive(false);
        gameoverui.SetActive(true);
        finalScoreText.text = pc.plscore.ToString();
        finalBestText.gameObject.SetActive(false);
        pc.scoretext.text = pc.playerscore.ToString();

    }
    public  void gamestart()
    {
        mainMenuui.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene("start");
    }
    public void Quit()
    {
        Application.Quit();
       
    }
    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;

    }
    public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    


    }


}
