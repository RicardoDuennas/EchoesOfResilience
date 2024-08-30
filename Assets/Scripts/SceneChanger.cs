using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainFinal");
    }
    public void StartNarrative()
    {
        SceneManager.LoadScene("NarrativeUi");
    }
}
