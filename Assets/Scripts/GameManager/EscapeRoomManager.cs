using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EscapeRoomManager : MonoBehaviour
{
    [System.Serializable]
    public class Puzzle
    {
        public bool[] conditions = new bool[3];
    }

    public Puzzle[] puzzles = new Puzzle[4];

    //Puzzle 1: Put books on sockets
    //Puzzle 2: Reorder books on table
    //Puzzle 3: Launch dats to map
    
    public Text statusText;

    private bool gameOver = false;

    void Start()
    {
    }

    void Update()
    {
        if (!gameOver)
        {
            CheckPuzzleCompletion();
        }
    }

    void CheckPuzzleCompletion()
    {
        bool allPuzzlesCompleted = true;

        foreach (Puzzle puzzle in puzzles)
        {
            bool puzzleCompleted = true;
            foreach (bool condition in puzzle.conditions)
            {
                if (!condition)
                {
                    puzzleCompleted = false;
                    break;
                }
            }

            if (!puzzleCompleted)
            {
                allPuzzlesCompleted = false;
                break;
            }
        }

        if (allPuzzlesCompleted)
        {
            EndGame(true);
        }
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
}