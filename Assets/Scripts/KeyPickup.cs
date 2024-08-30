using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyPickup : MonoBehaviour
{
    public EscapeRoomManager escapeRoomManager;
    public int puzzleIndex = 2; // Índice del tercer puzzle (el de la llave)
    public int conditionIndex = 0; // Sólo hay una condición en este puzzle

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Cumple la condición del tercer puzzle
        escapeRoomManager.SetPuzzleCondition(puzzleIndex, conditionIndex, true);
        // Reproduce el sonido del elemento final
        AudioManager.Instance.vFXSource.PlayOneShot(AudioManager.Instance.sonidosVoces[3]);
        // Destruye la llave o desactívala
        Destroy(gameObject);
    }
}
