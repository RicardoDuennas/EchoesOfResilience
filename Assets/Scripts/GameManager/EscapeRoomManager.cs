using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EscapeRoomManager : MonoBehaviour
{
    [System.Serializable]
    public class Puzzle
    {
        public bool[] conditions;
        public bool isCompleted = false;
    }

    public Puzzle[] puzzles;

    public Text statusText;
    public ParticleSystem chestParticleSystem;
    private bool gameOver = false;

    void Start()
    {
        AudioManager.Instance.vFXSource.PlayOneShot(AudioManager.Instance.sonidosVoces[0]);
    }

    void Update()
    {
        if (!gameOver)
        {
            CheckPuzzleCompletion();
        }
    }

    public void CheckPuzzleCompletion()
    {
        bool allPuzzlesCompleted = true;

        for (int i = 0; i < puzzles.Length; i++)
        {
            Puzzle puzzle = puzzles[i];
            bool puzzleCompleted = true;


            foreach (bool condition in puzzle.conditions)
            {
                if (!condition)
                {
                    puzzleCompleted = false;
                    break;
                }
            }

            // Si todas las condiciones del Puzzle 1 (índice 0) se cumplen
            if (i == 0 && puzzleCompleted && !puzzle.isCompleted)
            {
                puzzle.isCompleted = true;
                StartCoroutine(PlayWinPuzzleSoundWithDelay(2f));  // Reproduce el sonido con un delay de 2 segundos
                StartCoroutine(ReproduccionPista(1, 4f));
            }

            if (i == 1 && puzzleCompleted && !puzzle.isCompleted)
            {
                puzzle.isCompleted = true;
                StartCoroutine(ReproduccionPista(2, 4f));
                StartCoroutine(ActivateChestParticles(4f));
            }
            if (!puzzleCompleted)
            {
                allPuzzlesCompleted = false;
            }
        }

        if (allPuzzlesCompleted)
        {
            EndGame(true);
        }
    }

    private IEnumerator PlayWinPuzzleSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioManager.Instance.PlayWinPuzzleSound();
    }

    public void SetPuzzleCondition(int puzzleIndex, int conditionIndex, bool value)
    {
        if (puzzleIndex >= 0 && puzzleIndex < puzzles.Length &&
            conditionIndex >= 0 && conditionIndex < puzzles[puzzleIndex].conditions.Length)
        {
            puzzles[puzzleIndex].conditions[conditionIndex] = value;
        }
    }

    void EndGame(bool success)
    {
        gameOver = true;
        if (success)
        {
            statusText.text = "Congratulations! You've escaped the room!";
        }
        else
        {
            statusText.text = "Time's up! Better luck next time.";
        }
    }
    private IEnumerator ReproduccionPista(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioManager.Instance.vFXSource.PlayOneShot(AudioManager.Instance.sonidosVoces[index]);
    }

    // Nuevo método para activar las partículas del cofre después de un delay
    private IEnumerator ActivateChestParticles(float delay)
    {
        yield return new WaitForSeconds(delay);
        chestParticleSystem.Play();
    }

}
