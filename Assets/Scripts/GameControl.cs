using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    public int totalScore;
    public TMP_Text scoreText;

    //public static GameControl Instance;

    public GameObject gameOverPanel;
    public static GameControl Instance;
    public GameObject gamePassPanel;
    public GameObject gameExitPanel;
    public GameObject himeTalkPanel;





    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void UpdateTotalScore()
    {
        this.scoreText.text = totalScore.ToString();
    }


    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void ShowGamePassPanel()
    {
        gamePassPanel.SetActive(true);
    }
    public void ShowHimeTalkPanel()
    {
        himeTalkPanel.SetActive(true);
    }
    public void ShowGameExitPanel()
    {
        gameExitPanel.SetActive(true);
    }

    public void RestartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void PageTurns(string PageName)
    {
        SceneManager.LoadScene(PageName);
    }
    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
