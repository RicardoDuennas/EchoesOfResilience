using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
}
