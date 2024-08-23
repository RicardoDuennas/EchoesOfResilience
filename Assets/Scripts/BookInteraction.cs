using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteraction : MonoBehaviour
{
    public GameObject infoPanel; 

    
    private void OnMouseDown()
    {
        
        infoPanel.SetActive(true);
    }

    // Método para cerrar el papiro con el boton X
    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }
}