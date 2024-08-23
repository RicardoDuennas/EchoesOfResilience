using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 300f; // 5 minutos en segundos
    public Text timerText; //  texto para mostrar el tiempo
    public GameObject gameOverPanel; // Referencia al panel de Game Over

    private bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Detener el tiempo
    }
}
