using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    // Referencia al GameObject que representa el menú
    public GameObject menu;

    // Este método se llamará cuando se haga clic en el botón
    public void OnStartButtonClicked()
    {
        // Desactiva el menú
        menu.SetActive(false);
    }
}
