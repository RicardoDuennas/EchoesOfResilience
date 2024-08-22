using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float gameDuration = 300f; // 5 minutos en segundos
    private float timeRemaining;
    public GameObject gameOverMenu;

    void Start()
    {
        timeRemaining = gameDuration;
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Detén el tiempo y activa el menú de "Game Over"
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }
}
