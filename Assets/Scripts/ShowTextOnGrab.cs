using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowTextOnGrab : MonoBehaviour
{
    public GameObject canvas; 
    
    private void Start()
    {
        canvas.SetActive(false); 
    }

    
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        canvas.SetActive(true); 
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        canvas.SetActive(false); 
    }
}