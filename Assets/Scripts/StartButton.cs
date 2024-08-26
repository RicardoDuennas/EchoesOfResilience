using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject menu;

    public void OnStartButtonClicked()
    {
        menu.SetActive(false);
    }

    void Start()
    {
        menu.SetActive(true);
    }
}
