using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject winPanel;
    public GameObject gameOverPanel;

    public void OnStartButtonClicked()
    {
        startMenu.SetActive(false);
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void OnRestartButtonClicked()
    {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
